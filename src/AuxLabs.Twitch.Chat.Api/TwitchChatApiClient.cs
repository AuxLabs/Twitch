using AuxLabs.Twitch.Chat.Models;
using AuxLabs.Twitch.Chat.Requests;
using AuxLabs.Twitch.WebSockets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Chat.Api
{
    public class TwitchChatApiClient : IDisposable
    {
        #region Events

        /// <summary> The client has successfully made a connection to the server. </summary>
        public event Action Connected;
        /// <summary> The client was forcibly disconnected from the server. </summary>
        public event Action<Exception> Disconnected;
        /// <summary> An unhandled irc command was received. </summary>
        public event Action<IrcPayload> UnknownEventReceived;
        /// <summary> Triggered when the server needs to terminate the connection. </summary>
        public event Action Reconnect;

        /// <summary> Triggered after successful authentication. </summary>
        public event Action<IReadOnlyCollection<string>> CapabilityAcknowledged;
        /// <summary> Triggered when authenticating with invalid capabilities </summary>
        public event Action<IReadOnlyCollection<string>> CapabilityDenied;
        /// <summary> Triggered when someone removes all messages from the channel or from a specified user. </summary>
        public event Action<ClearChatEventArgs> ChatCleared;
        /// <summary> Triggered when someone removes a single message from the chat room. </summary>
        public event Action<ClearMessageEventArgs> MessageCleared;
        /// <summary> Triggered after authenticated with the server. Indicates the authenticated user's chat settings. </summary>
        public event Action<GlobalUserStateTags> GlobalUserStateReceived;
        /// <summary> Triggered to indicate the outcome of an action. </summary>
        public event Action<NoticeEventArgs> NoticeReceived;
        /// <summary> Triggered when a message is received in a channel. </summary>
        public event Action<MessageEventArgs> MessageReceived;
        /// <summary> Triggered when you join a channel or when the channel’s chat settings change. Indicates the chat's current settings. </summary>
        public event Action<RoomStateEventArgs> RoomStateReceived;
        /// <summary> Triggered when events relating to a user in a channel occur. e.g. subscriptions, gifts, raids... </summary>
        public event Action<UserNoticeEventArgs> UserNoticeReceived;
        /// <summary> Triggered when the bot joins a channel. Indicates the authenticated user's state in said channel. </summary>
        public event Action<UserStateEventArgs> UserStateReceived;
        /// <summary> Triggered when a whisper is received. </summary>
        public event Action<WhisperEventArgs> WhisperReceived;
        /// <summary> Triggered when a user joins a channel. </summary>
        public event Action<MembershipEventArgs> ChannelJoined;
        /// <summary> Triggered when a user leaves a channel. </summary>
        public event Action<MembershipEventArgs> ChannelLeft;
        /// <summary> Triggered after joining a channel, lists current active chatters. </summary>
        public event Action<NamesEventArgs> NamesReceived;

        #endregion

        // config variables
        public readonly bool CommandsRequested;
        public readonly bool TagsRequested;
        public readonly bool ThrowOnUnknownEvent;
        public readonly bool ThrowOnUnhandledTags;
        public readonly bool UseVerifiedRateLimits;

        public ConnectionState State => _client.State;
        public bool IsAnonymous { get; private set; } = false;

        private readonly ISocketClient<IrcPayload> _client;
        private readonly string _url = null;

        private bool _disposed = false;
        private string _username = null;
        private string _token = null;

        public TwitchChatApiClient(TwitchChatApiConfig config = null)
            : this(TwitchConstants.ChatSecureWebSocketUrl, config) { }
        public TwitchChatApiClient(string url, TwitchChatApiConfig config = null)
        {
            config ??= new TwitchChatApiConfig();
            _url = url;

            var serializer = config.IrcSerializer ?? new DefaultIrcSerializer(config.ThrowOnUnhandledTags);
            _client = new DefaultSocketClient<IrcPayload>(serializer, new DefaultSocketClientConfig
            {
                IsRecursive = true
            });

            _client.Connected += () => Connected?.Invoke();
            _client.Disconnected += ex => Disconnected?.Invoke(ex);
            _client.PayloadReceived += OnPayloadReceived;
            _client.Identify += OnIdentify;

            CommandsRequested = config.RequestCommands;
            TagsRequested = config.RequestTags;
            ThrowOnUnknownEvent = config.ThrowOnUnknownEvent;
            ThrowOnUnhandledTags = config.ThrowOnUnhandledTags;
            UseVerifiedRateLimits = config.UseVerifiedRateLimits;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _client.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public TwitchChatApiClient WithIdentity(string username, string token)
        {
            if (State == ConnectionState.Connected)
                throw new InvalidOperationException("Identity can't be changed after connection");

            Require.NotNullOrWhitespace(username, nameof(username));
            Require.NotNullOrWhitespace(token, nameof(token));

            if (username.StartsWith(TwitchConstants.AnonymousNamePrefix) && 
                token.StartsWith(TwitchConstants.AnonymousNamePrefix))
                IsAnonymous = true;

            _username = username;
            if (!token.StartsWith("oauth:"))
                token = token.Insert(0, "oauth:");
            _token = token;

            return this;
        }

        public void Run() => _client.Run(_url);
        public Task RunAsync() => _client.RunAsync(_url);

        /// <summary> Join a channel by name. </summary>
        /// <remarks> Max channels per request is 20 or 2000 for verified accounts. </remarks>
        public void SendJoin(params string[] channelNames)
        {
            var request = new JoinChannelsRequest(channelNames);
            request.Validate(UseVerifiedRateLimits);

            _client.Send(request.CreateRequest());
        }

        /// <summary> Leave a channel by name. </summary>
        /// <remarks> Max channels per request is 20 or 2000 for verified accounts. </remarks>
        public void SendPart(params string[] channelNames)
        {
            var request = new PartChannelsRequest(channelNames);
            request.Validate(UseVerifiedRateLimits);

            _client.Send(request.CreateRequest());
        }

        /// <summary> Send a message to a channel. </summary>
        public void SendMessage(string channelName, string message, string replyMessageId = null)
        {
            var request = new SendMessageRequest(channelName, message, replyMessageId);
            request.Validate(UseVerifiedRateLimits);

            _client.Send(request.CreateRequest());
        }

        private void OnIdentify()
        {
            var capReq = new CapabilityRequest(tags: TagsRequested, commands: CommandsRequested);
            if (capReq.HasData) _client.Send(capReq);

            _client.Send(new IrcPayload(IrcCommand.Password, _token));
            _client.Send(new IrcPayload(IrcCommand.Nickname, _username));
        }

        private void OnPayloadReceived(IrcPayload payload, TaskCompletionSource<bool> readySignal)
        {
            switch (payload.Command)
            {
                case IrcCommand.Reconnect:
                    Reconnect?.Invoke();
                    break;
                case IrcCommand.Ping:
                    _client.Send(new IrcPayload
                    {
                        Command = IrcCommand.Pong
                    });
                    break;
                case IrcCommand.CapabilityAcknowledge:
                    readySignal.TrySetResult(true);
                    CapabilityAcknowledged?.Invoke(payload.Parameters);
                    break;
                case IrcCommand.CapabilityDenied:
                    CapabilityDenied?.Invoke(payload.Parameters);
                    break;

                case IrcCommand.GlobalUserState:
                    readySignal.TrySetResult(true);
                    GlobalUserStateReceived?.Invoke((GlobalUserStateTags)payload.Tags);
                    break;

                case IrcCommand.ClearChat:
                    var clearChatArgs = ClearChatEventArgs.Create(payload);
                    ChatCleared?.Invoke(clearChatArgs);
                    break;

                case IrcCommand.ClearMessage:
                    var clearMsgArgs = ClearMessageEventArgs.Create(payload);
                    MessageCleared?.Invoke(clearMsgArgs);
                    break;

                case IrcCommand.Message:
                    var messageArgs = MessageEventArgs.Create(payload);
                    MessageReceived?.Invoke(messageArgs);
                    break;

                case IrcCommand.RoomState:
                    var roomStateArgs = RoomStateEventArgs.Create(payload);
                    RoomStateReceived?.Invoke(roomStateArgs);
                    break;

                case IrcCommand.UserNotice:
                    var userNoticeArgs = UserNoticeEventArgs.Create(payload);
                    UserNoticeReceived?.Invoke(userNoticeArgs);
                    break;

                case IrcCommand.UserState:
                    var userStateArgs = UserStateEventArgs.Create(payload);
                    UserStateReceived?.Invoke(userStateArgs);
                    break;

                case IrcCommand.Whisper:
                    var whisperArgs = WhisperEventArgs.Create(payload);
                    WhisperReceived?.Invoke(whisperArgs);
                    break;

                case IrcCommand.Join:
                    var joinArgs = MembershipEventArgs.Create(payload);
                    ChannelJoined?.Invoke(joinArgs);
                    break;

                case IrcCommand.Part:
                    var leftArgs = MembershipEventArgs.Create(payload);
                    ChannelLeft?.Invoke(leftArgs);
                    break;

                case IrcCommand.NamesList:
                    var namesArgs = new NamesEventArgs(payload.Parameters);
                    NamesReceived?.Invoke(namesArgs);
                    break;
                case IrcCommand.NamesEnd:
                    break;

                case IrcCommand.Notice:
                    var noticeArgs = NoticeEventArgs.Create(payload);
                    NoticeReceived?.Invoke(noticeArgs);
                    break;

                case IrcCommand.RPL_Welcome:        // Ignorable messages sent after authentication
                case IrcCommand.RPL_YourHost:
                case IrcCommand.RPL_Created:
                case IrcCommand.RPL_MyInfo:
                case IrcCommand.RPL_MotdStart:
                case IrcCommand.RPL_Motd:
                case IrcCommand.RPL_MotdEnd:
                    break;

                default:
                    UnknownEventReceived?.Invoke(payload);
                    if (ThrowOnUnknownEvent)
                        throw new TwitchChatException($"An unhandled event of type `{payload.CommandRaw}` was received");
                    break;
            };
        }
    }
}

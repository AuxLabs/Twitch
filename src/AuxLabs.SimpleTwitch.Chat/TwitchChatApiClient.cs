using AuxLabs.SimpleTwitch.WebSockets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : BaseSocketClient<IrcPayload>
    {
        #region Events

        /// <summary> Triggered when the Twitch IRC server needs to terminate the connection. </summary>
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
        public readonly bool ShouldHandleEvents;
        public readonly bool ThrowOnUnknownEvent;
        public readonly bool ThrowOnMismatchedTags;

        protected override ISerializer<IrcPayload> Serializer { get; }

        private readonly string _url = null;
        private string _username = null;
        private string _token = null;
        private bool _anonymous = false;

        public TwitchChatApiClient(TwitchChatApiConfig config = null)
            : this(TwitchConstants.ChatSecureWebSocketUrl, config) { }
        public TwitchChatApiClient(string url, TwitchChatApiConfig config = null) : base(-1, false, true)
        {
            config ??= new TwitchChatApiConfig();
            _url = url;

            Serializer = config.IrcSerializer ?? new DefaultIrcSerializer(config.ThrowOnMismatchedTags);

            CommandsRequested = config.RequestCommands;
            TagsRequested = config.RequestTags;
            ShouldHandleEvents = config.ShouldHandleEvents;
            ThrowOnUnknownEvent = config.ThrowOnUnknownEvent;
            ThrowOnMismatchedTags = config.ThrowOnMismatchedTags;
        }

        public TwitchChatApiClient SetIdentity(string username, string token)
        {
            if (State == ConnectionState.Connected)
                throw new InvalidOperationException("Identity can't be changed after connection");

            Require.NotNullOrWhitespace(username, nameof(username));
            Require.NotNullOrWhitespace(token, nameof(token));

            if (username.StartsWith(TwitchConstants.AnonymousNamePrefix) && token.StartsWith(TwitchConstants.AnonymousNamePrefix))
                _anonymous = true;

            _username = username;
            if (!token.StartsWith("oauth:"))
                token = token.Insert(0, "oauth:");
            _token = token;

            return this;
        }

        public override void Run() => Run(_url);
        public override Task RunAsync() => RunAsync(_url);

        /// <summary> Join a channel by name. </summary>
        /// <remarks> Max channels per request is 20. </remarks>
        public void SendJoin(params string[] channelNames)
            => Send(new JoinChannelsRequest(channelNames));

        /// <summary> Leave a channel by name. </summary>
        /// <remarks> Max channels per request is 20. </remarks>
        public void SendPart(params string[] channelNames)
            => Send(new PartChannelsRequest(channelNames));

        /// <summary> Send a message to a channel. </summary>
        public void SendChannelMessage(string channelName, string message, string replyMessageId = null)
            => Send(new SendMessageRequest(channelName, message, replyMessageId));

        protected override void SendIdentify()
        {
            var capReq = new CapabilityRequest(tags: TagsRequested, commands: CommandsRequested);
            if (capReq.HasData) Send(capReq);

            Send(new IrcPayload(IrcCommand.Password, _token));
            Send(new IrcPayload(IrcCommand.Nickname, _username));
        }

        protected override void SendHeartbeat() => Send(new IrcPayload
        {
            Command = IrcCommand.Ping
        });

        protected override void SendHeartbeatAck() => Send(new IrcPayload
        {
            Command = IrcCommand.Pong
        });

        protected override void HandleEvent(IrcPayload payload, TaskCompletionSource<bool> readySignal)
        {
            if (State != ConnectionState.Connected && _anonymous)   // Anonymous never gets a globaluserstate
                readySignal.TrySetResult(true);

            if (payload.Command == IrcCommand.GlobalUserState) // This command is used to confirm authentication.
            {
                readySignal.TrySetResult(true);
                GlobalUserStateReceived?.Invoke((GlobalUserStateTags)payload.Tags);
                return;
            }

            if (!ShouldHandleEvents) return;
            switch (payload.Command)
            {
                case IrcCommand.Reconnect:
                    Reconnect?.Invoke();
                    break;
                case IrcCommand.Ping:
                    SendHeartbeatAck();
                    break;
                case IrcCommand.CapabilityAcknowledge:
                    readySignal.TrySetResult(true);
                    CapabilityAcknowledged?.Invoke(payload.Parameters);
                    break;
                case IrcCommand.CapabilityDenied:
                    CapabilityDenied?.Invoke(payload.Parameters);
                    break;

                case IrcCommand.ClearChat:
                    var clearChatArgs = ClearChatEventArgs.Create(payload);
                    ChatCleared?.Invoke(clearChatArgs);
                    break;

                case IrcCommand.ClearMessage:
                    var clearMsgArgs = ClearMessageEventArgs.Create(payload);
                    MessageCleared?.Invoke(clearMsgArgs);
                    break;

                case IrcCommand.Notice:
                    var noticeArgs = NoticeEventArgs.Create(payload);
                    NoticeReceived?.Invoke(noticeArgs);
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

                case IrcCommand.RPL_Welcome:        // Ignorable messages sent after authentication
                case IrcCommand.RPL_YourHost:
                case IrcCommand.RPL_Created:
                case IrcCommand.RPL_MyInfo:
                case IrcCommand.RPL_MotdStart:
                case IrcCommand.RPL_Motd:
                case IrcCommand.RPL_MotdEnd:
                    break;

                default:
                    OnUnknownEventReceived(payload);
                    if (ThrowOnUnknownEvent)
                        throw new TwitchException($"An unhandled event of type `{payload.CommandRaw}` was received");
                    break;
            };
        }
    }
}

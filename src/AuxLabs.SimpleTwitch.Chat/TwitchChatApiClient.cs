using AuxLabs.SimpleTwitch.Sockets;
using System;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : BaseSocketClient<IrcPayload>
    {
        /// <summary> Triggered when the Twitch IRC server needs to terminate the connection. </summary>
        public event Action Reconnect;

        /// <summary> Triggered when an unhandled irc command is received. </summary>
        public event Action<IrcPayload> UnknownCommandReceived;
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
        public event Action<object> UserStateReceived;
        /// <summary> Triggered when a whisper is received. </summary>
        public event Action<object> WhisperReceived;
        /// <summary> Triggered when a user joins a channel. </summary>
        public event Action<MembershipEventArgs> ChannelJoined;
        /// <summary> Triggered when a user leaves a channel. </summary>
        public event Action<MembershipEventArgs> ChannelLeft;

        // config variables
        public readonly bool CommandsRequested;
        public readonly bool MembershipRequested;
        public readonly bool TagsRequested;
        public readonly bool ThrowOnUnknownCommand;

        protected override ISerializer<IrcPayload> Serializer { get; }

        public TwitchChatApiClient(TwitchChatConfig config = null) : base(-1)
        {
            config ??= new TwitchChatConfig();

            Serializer = config.IrcSerializer ?? new DefaultIrcSerializer();

            CommandsRequested = config.RequestCommands;
            MembershipRequested = config.RequestMembership;
            TagsRequested = config.RequestTags;
            ThrowOnUnknownCommand = config.ThrowOnUnknownCommand;
        }

        public void Run()
            => Run(TwitchConstants.ChatSecureWebSocketUrl);
        public Task RunAsync()
            => RunAsync(TwitchConstants.ChatSecureWebSocketUrl);

        public override void SendIdentify(string username, string password)
        {
            if (!password.StartsWith("oauth:"))
                password = password.Insert(0, "oauth:");

            var capReq = new CapabilityRequest(membership: MembershipRequested, tags: TagsRequested, commands: CommandsRequested);
            if (capReq.IsValid) Send(capReq);

            Send(new IrcPayload(IrcCommand.Password, password));
            Send(new IrcPayload(IrcCommand.Nickname, username));
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
            bool hasTags = payload.Tags != null;

            switch (payload.Command)
            {
                case IrcCommand.Reconnect:
                    Reconnect?.Invoke();
                    break;

                case IrcCommand.ClearChat:
                    var clearChatArgs = new ClearChatEventArgs(payload.Parameters);
                    if (hasTags) clearChatArgs.Tags = (ClearChatTags)payload.Tags;
                    ChatCleared?.Invoke(clearChatArgs);
                    break;

                case IrcCommand.ClearMessage:
                    var clearMsgArgs = new ClearMessageEventArgs(payload.Parameters);
                    if (hasTags) clearMsgArgs.Tags = (ClearMessageTags)payload.Tags;
                    MessageCleared?.Invoke(clearMsgArgs);
                    break;

                case IrcCommand.GlobalUserState:
                    GlobalUserStateReceived?.Invoke((GlobalUserStateTags)payload.Tags);
                    break;

                case IrcCommand.Notice:
                    var noticeArgs = new NoticeEventArgs(payload.Parameters);
                    if (hasTags) noticeArgs.Tags = (NoticeTags)payload.Tags;
                    NoticeReceived?.Invoke(noticeArgs);
                    break;

                case IrcCommand.Message:
                    var messageArgs = new MessageEventArgs(payload.Prefix, payload.Parameters);
                    if (hasTags) messageArgs.Tags = (MessageTags)payload.Tags;
                    MessageReceived?.Invoke(messageArgs);
                    break;

                case IrcCommand.RoomState:
                    var roomStateArgs = new RoomStateEventArgs(payload.Parameters);
                    if (hasTags) roomStateArgs.Tags = (RoomStateTags)payload.Tags;
                    RoomStateReceived?.Invoke(roomStateArgs);
                    break;

                case IrcCommand.UserNotice:
                    var userNoticeArgs = new UserNoticeEventArgs(payload.Parameters);
                    if (hasTags) userNoticeArgs.Tags = (UserNoticeTags)payload.Tags;
                    UserNoticeReceived?.Invoke(userNoticeArgs);
                    break;

                case IrcCommand.UserState:
                    break;

                case IrcCommand.Whisper:
                    break;

                case IrcCommand.Join:
                    var joinArgs = new MembershipEventArgs(payload.Prefix.Value, payload.Parameters);
                    ChannelJoined?.Invoke(joinArgs);
                    break;

                case IrcCommand.Part:
                    var leftArgs = new MembershipEventArgs(payload.Prefix.Value, payload.Parameters);
                    ChannelLeft?.Invoke(leftArgs);
                    break;

                case IrcCommand.Mode:
                    break;
                case IrcCommand.Names:
                    break;
                case IrcCommand.NamesList:
                    break;
                case IrcCommand.NamesEnd:
                    break;
                case IrcCommand.CapabilityAcknowledge:
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
                    UnknownCommandReceived?.Invoke(payload);
                    if (ThrowOnUnknownCommand)
                        throw new TwitchException($"An unhandled event of type `{payload.CommandRaw}` was received", payload);
                    break;
            };
        }
    }
}

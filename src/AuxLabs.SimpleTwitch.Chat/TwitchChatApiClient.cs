using AuxLabs.SimpleTwitch.Sockets;
using System;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : BaseSocketClient<IrcPayload>
    {
        public event Action<IrcPayload> UnknownCommandReceived;

        public event Action<ClearChatEventArgs> ChatCleared;
        public event Action<ClearMessageEventArgs> MessageCleared;
        public event Action<MessageEventArgs> MessageReceived;
        public event Action<GlobalUserStateTags> GlobalUserStateReceived;

        public event Action<RoomStateEventArgs> RoomStateReceived;

        public event Action<MembershipEventArgs> ChannelJoined;
        public event Action<MembershipEventArgs> ChannelLeft;
        public event Action<NoticeEventArgs> NoticeReceived;
        public event Action<UserNoticeEventArgs> UserNoticeReceived;

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

                case IrcCommand.Message:
                    var messageArgs = new MessageEventArgs(payload.Prefix, payload.Parameters);
                    if (hasTags) messageArgs.Tags = (MessageTags)payload.Tags;
                    MessageReceived?.Invoke(messageArgs);
                    break;

                case IrcCommand.Mode:
                    break;

                case IrcCommand.Names:
                    break;
                case IrcCommand.NamesList:
                    break;
                case IrcCommand.NamesEnd:
                    break;
                case IrcCommand.Reconnect:
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
                case IrcCommand.GlobalUserState:
                    GlobalUserStateReceived?.Invoke((GlobalUserStateTags)payload.Tags);
                    break;

                case IrcCommand.CapabilityAcknowledge:
                    break;

                case IrcCommand.Join:
                    var joinArgs = new MembershipEventArgs(payload.Prefix.Value, payload.Parameters);
                    ChannelJoined?.Invoke(joinArgs);
                    break;

                case IrcCommand.Part:
                    var leftArgs = new MembershipEventArgs(payload.Prefix.Value, payload.Parameters);
                    ChannelLeft?.Invoke(leftArgs);
                    break;

                case IrcCommand.Notice:
                    var noticeArgs = new NoticeEventArgs(payload.Parameters);
                    if (hasTags) noticeArgs.Tags = (NoticeTags)payload.Tags;
                    NoticeReceived?.Invoke(noticeArgs);
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

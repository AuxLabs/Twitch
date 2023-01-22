using AuxLabs.SimpleTwitch.Chat.Models;
using AuxLabs.SimpleTwitch.Chat.Requests;
using AuxLabs.SimpleTwitch.Sockets;
using System.Text;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : BaseSocketClient<IrcPayload>
    {
        public event Action<IrcPayload> UnknownCommandReceived;

        public event Action<ClearChatEventArgs> ChatCleared;
        public event Action<MessageEventArgs> MessageReceived;
        public event Action<GlobalUserStateTags> GlobalUserStateReceived;
        public event Action<NoticeEventArgs> NoticeReceived;

        // config variables
        public readonly bool CommandsRequested;
        public readonly bool MembershipRequested;
        public readonly bool TagsRequested;

        protected override ISerializer<IrcPayload> Serializer { get; }

        public TwitchChatApiClient(TwitchChatConfig config = null) : base(-1)
        {
            if (config == null) config = new TwitchChatConfig();

            Serializer = config.IrcSerializer ?? new DefaultIrcSerializer();

            CommandsRequested = config.RequestCommands;
            MembershipRequested = config.RequestMembership;
            TagsRequested = config.RequestTags;
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
            var parameters = Array.Empty<string>();

            switch (payload.Command)
            {
                case IrcCommand.ClearChat:
                    var clearChatArgs = new ClearChatEventArgs(payload.Parameters);
                    if (hasTags)
                        clearChatArgs.Tags = (ClearChatTags)payload.Tags;
                    ChatCleared?.Invoke(clearChatArgs);
                    break;

                case IrcCommand.ClearMessage:
                    break;

                case IrcCommand.Message:
                    var messageArgs = new MessageEventArgs(payload.Prefix, payload.Parameters);
                    if (hasTags)
                        messageArgs.Tags = (MessageTags)payload.Tags;
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
                    break;
                case IrcCommand.UserNotice:
                    break;
                case IrcCommand.UserState:
                    break;
                case IrcCommand.GlobalUserState:
                    GlobalUserStateReceived?.Invoke((GlobalUserStateTags)payload.Tags);
                    break;

                case IrcCommand.CapabilityAcknowledge:
                    break;

                case IrcCommand.Join:
                    break;
                case IrcCommand.Part:
                    break;

                case IrcCommand.Notice:
                    var noticeArgs = new NoticeEventArgs(payload.Parameters);
                    if (hasTags)
                        noticeArgs.Tags = (NoticeTags)payload.Tags;
                    NoticeReceived?.Invoke(noticeArgs);
                    break;

                default:
                    UnknownCommandReceived?.Invoke(payload);
                    break;
            };
        }
    }
}

using AuxLabs.SimpleTwitch.Chat.Models;
using AuxLabs.SimpleTwitch.Sockets;
using System.Net.WebSockets;
using System.Text;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : BaseSocketClient<IrcPayload>
    {
        public event Action<IrcPayload> UnknownCommandReceived;

        public event Action<ClearChatEventArgs> ChatCleared;
        public event Action<MessageEventArgs> MessageReceived;
        public event Action<GlobalUserStateTags> GlobalUserStateReceived;

        // config variables
        private readonly bool _commandsRequested;
        private readonly bool _membershipRequested;
        private readonly bool _tagsRequested;

        protected override ISerializer<IrcPayload> Serializer { get; }

        public TwitchChatApiClient(TwitchChatConfig config = default) : base(-1)
        {
            Serializer = config.IrcSerializer ?? new DefaultIrcSerializer();

            _commandsRequested = config.RequestCommands;
            _membershipRequested = config.RequestMembership;
            _tagsRequested = config.RequestTags;
        }

        public void Run()
            => Run(TwitchConstants.ChatSecureWebSocketUrl);
        public Task RunAsync()
            => RunAsync(TwitchConstants.ChatSecureWebSocketUrl);

        public override void SendIdentify(string username, string password)
        {
            if (!password.StartsWith("oauth:"))
                password = password.Insert(0, "oauth:");

            var builder = new StringBuilder();
            if (_membershipRequested)
                builder.Append("twitch.tv/membership ");
            if (_commandsRequested)
                builder.Append("twitch.tv/commands ");
            if (_tagsRequested)
                builder.Append("twitch.tv/tags");
            if (builder.Length > 0)
            {
                builder.Insert(0, ":");
                Send(new IrcPayload(IrcCommand.CapabilityRequest, builder.ToString()));
            }

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
                    var clearChatArgs = new ClearChatEventArgs();
                    if (hasTags)
                    {
                        clearChatArgs.Tags = new();
                        clearChatArgs.Tags.LoadQueryMap(payload.Tags);
                    }

                    parameters = payload.Parameters.Split(' ');
                    clearChatArgs.ChannelName = parameters[0].Trim('#');
                    clearChatArgs.UserName = parameters.ElementAtOrDefault(1)?.Trim(':');

                    ChatCleared?.Invoke(clearChatArgs);
                    break;
                case IrcCommand.ClearMessage:
                    break;
                case IrcCommand.Message:
                    var messageArgs = new MessageEventArgs();
                    if (hasTags)
                    {
                        messageArgs.Tags = new();
                        messageArgs.Tags.LoadQueryMap(payload.Tags);
                    }

                    parameters = payload.Parameters.Split(' ', 2);
                    messageArgs.ChannelName = parameters[0].Trim('#');
                    messageArgs.Message = parameters.LastOrDefault().Trim(':');
                    messageArgs.UserName = payload.Prefix?.Username;

                    MessageReceived?.Invoke(messageArgs);
                    break;
                case IrcCommand.Mode:
                    break;

                case IrcCommand.Names:
                    break;
                case IrcCommand.NamesStart:
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
                    var globalUserStateTags = new GlobalUserStateTags();
                    if (hasTags)
                        globalUserStateTags.LoadQueryMap(payload.Tags);
                    GlobalUserStateReceived?.Invoke(globalUserStateTags);
                    break;
                case IrcCommand.CapabilityAcknowledge:
                    break;

                case IrcCommand.Join:
                    break;
                case IrcCommand.Part:
                    break;

                case IrcCommand.Notice:
                    HandleNoticeEvent(payload, readySignal);
                    break;
                default:
                    UnknownCommandReceived?.Invoke(payload);
                    break;
            };
        }

        private void HandleNoticeEvent(IrcPayload payload, TaskCompletionSource<bool> readySignal)
        {

        }
    }
}

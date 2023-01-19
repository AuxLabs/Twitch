using AuxLabs.SimpleTwitch.Chat.Models;
using AuxLabs.SimpleTwitch.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : BaseSocketClient<IrcMessage>
    {
        public event Action<ClearChatEventArgs> ChatCleared;
        public event Action<MessageEventArgs> MessageReceived;

        public TwitchChatConfig Config { get; }

        private readonly IIrcSerializer _serializer;
        private readonly MemoryStream _stream;
        private int _lastSeq;
        private bool _receivedData;

        public TwitchChatApiClient(TwitchChatConfig config = default) : base(-1)
        {
            Config = config;
            _serializer = Config.IrcSerializer ?? new DefaultIrcSerializer();
            _stream = new MemoryStream();
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
            if (Config.RequestMembership)
                builder.Append("twitch.tv/membership ");
            if (Config.RequestCommands)
                builder.Append("twitch.tv/commands ");
            if (Config.RequestTags)
                builder.Append("twitch.tv/tags");
            if (builder.Length > 0)
            {
                builder.Insert(0, ":");
                Send(new IrcMessage(IrcCommand.CapabilityRequest, builder.ToString()));
            }

            Send(new IrcMessage(IrcCommand.Password, password));
            Send(new IrcMessage(IrcCommand.Nickname, username));
        }

        protected override async Task SendAsync(ClientWebSocket client, IrcMessage payload, CancellationToken cancelToken)
        {
            var data = _serializer.Write(payload);
            await client.SendAsync(data, WebSocketMessageType.Text, true, cancelToken);
            OnPayloadSent(payload, data.Length);
        }
        protected override void OnPayloadSent(IrcMessage payload, int bufferSize)
            => base.OnPayloadSent(payload, bufferSize);

        protected override void SendHeartbeat() => Send(new IrcMessage
        {
            Command = IrcCommand.Ping
        });

        protected override void SendHeartbeatAck() => Send(new IrcMessage
        {
            Command = IrcCommand.Pong
        });

        protected override async Task<IrcMessage> ReceiveAsync(ClientWebSocket client, TaskCompletionSource<bool> readySignal, CancellationToken cancelToken)
        {
            _stream.Position = 0;
            _stream.SetLength(0);

            WebSocketReceiveResult result;
            do
            {
                var buffer = new ArraySegment<byte>(new byte[10 * 1024]);
                result = await client.ReceiveAsync(buffer, cancelToken).ConfigureAwait(false);
                _stream.Write(buffer.ToArray(), 0, result.Count);

                _receivedData = true;

                if (result.CloseStatus != null)
                    throw new Sockets.WebSocketClosedException(result.CloseStatus.Value, result.CloseStatusDescription);
            }
            while (!result.EndOfMessage);

            var payload = _serializer.Read(_stream.ToArray());

            HandleEvent(payload, readySignal); // Must be before event so slow user handling can't trigger timeouts
            OnPayloadReceived(payload, _stream.Length);
            return payload;
        }
        protected override void OnPayloadReceived(IrcMessage payload, long bufferSize)
            => base.OnPayloadReceived(payload, bufferSize);

        protected override void HandleEvent(IrcMessage payload, TaskCompletionSource<bool> readySignal)
        {
            bool hasTags = payload.Tags != null;
            var parameters = new string[0];

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
                    messageArgs.UserName = payload.Prefix.Username;

                    MessageReceived?.Invoke(messageArgs);
                    break;

                case IrcCommand.Ping:
                    break;
                case IrcCommand.Pong:
                    break;
                case IrcCommand.Mode:
                    break;

                case IrcCommand.Names:
                    break;
                case IrcCommand.NamesStart:
                    break;
                case IrcCommand.NamesEnd:
                    break;

                case IrcCommand.Notice:
                    break;
                case IrcCommand.Reconnect:
                    break;
                case IrcCommand.RoomState:
                    break;
                case IrcCommand.UserNotice:
                    break;
                case IrcCommand.UserState:
                    break;
                case IrcCommand.CapabilityAcknowledge:
                    break;

                case IrcCommand.Join:
                    break;
                case IrcCommand.Part:
                    break;
                default:
                    break;
            };
        }
    }
}

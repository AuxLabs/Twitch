using AuxLabs.SimpleTwitch.Chat.Models;
using AuxLabs.SimpleTwitch.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : BaseSocketClient<IrcMessage>
    {
        public event Action<ClearChatTags, string, string> ChatCleared;

        public TwitchChatConfig Config { get; }

        private readonly MemoryStream _stream;
        private int _lastSeq;
        private bool _receivedData;

        public TwitchChatApiClient(TwitchChatConfig config = default) : base(-1)
        {
            Config = config;
            _stream = new MemoryStream();
        }

        public void Run()
            => Run(TwitchConstants.ChatSecureWebSocketUrl);
        public Task RunAsync()
            => RunAsync(TwitchConstants.ChatSecureWebSocketUrl);

        public override void SendIdentify(string username, string password)
        {
            if (!password.StartsWith("oauth:"))
                password.Insert(0, "oauth:");

            Send(new IrcMessage(IrcCommand.Password, password));
            Send(new IrcMessage(IrcCommand.Nickname, username));

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
        }

        protected override async Task SendAsync(ClientWebSocket client, IrcMessage payload, CancellationToken cancelToken)
        {
            var data = JsonSerializer.SerializeToUtf8Bytes(payload); // Temporary not irc serializer
            var buffer = new ArraySegment<byte>(data, 0, data.Length);
            await client.SendAsync(buffer, WebSocketMessageType.Binary, true, cancelToken);
            OnPayloadSent(payload, buffer.Count);
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
                var buffer = _stream.GetBuffer();
                result = await client.ReceiveAsync(buffer, cancelToken).ConfigureAwait(false);
                _stream.Write(buffer);
                _receivedData = true;

                if (result.CloseStatus != null)
                    throw new Sockets.WebSocketClosedException(result.CloseStatus.Value, result.CloseStatusDescription);
            }
            while (!result.EndOfMessage);

            var value = Encoding.UTF8.GetString(_stream.ToArray());

            var payload = new IrcMessage();

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
                    ClearChatTags clearChatArgs = null;
                    if (hasTags)
                    {
                        clearChatArgs = new ClearChatTags();
                        clearChatArgs.LoadQueryMap(payload.Tags);
                    }

                    parameters = payload.Parameters.Split(' ');
                    var channelName = parameters[0].Trim('#');
                    var userName = parameters.ElementAtOrDefault(1)?.Trim(':');

                    ChatCleared?.Invoke(clearChatArgs, channelName, userName);
                    break;
                case IrcCommand.ClearMessage:
                    break;
                case IrcCommand.HostTarget:
                    break;
                case IrcCommand.Message:
                    break;

                case IrcCommand.Ping:
                    break;
                case IrcCommand.Pong:
                    break;
                case IrcCommand.Mode:
                    break;
                case IrcCommand.Names:
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

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

        public TwitchChatApiClient(TwitchChatConfig config = default) : base(-1)
        {
            Config = config;
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
        
        protected override void SendIdentify()
        {
            Send(new IrcMessage(IrcCommand.Password, ""));
            Send(new IrcMessage(IrcCommand.Nickname, ""));

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

        protected override void SendHeartbeat() => Send(new IrcMessage
        {
            Command = IrcCommand.Ping
        });

        protected override void SendHeartbeatAck() => Send(new IrcMessage
        {
            Command = IrcCommand.Pong
        });

        protected override Task<IrcMessage> ReceiveAsync(ClientWebSocket client, TaskCompletionSource<bool> readySignal, CancellationToken cancelToken)
        {
            return Task.FromResult(default(IrcMessage));
        }

        protected override void HandleEventAsync(IrcMessage payload, TaskCompletionSource<bool> readySignal)
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

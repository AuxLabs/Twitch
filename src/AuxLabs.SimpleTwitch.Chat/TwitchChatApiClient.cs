using AuxLabs.SimpleTwitch.Sockets;
using System.Net.WebSockets;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiClient : BaseSocketClient<IrcMessage>
    {
        public override void Send()
            => SendAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        public override Task SendAsync()
        {
            throw new NotImplementedException();
        }

        public override void SendIdentify()
        {
            throw new NotImplementedException();
        }

        public override void SendHeartbeat()
        {
            throw new NotImplementedException();
        }

        public override void SendHeartbeatAck()
        {
            throw new NotImplementedException();
        }

        public override Task<IrcMessage> ReceiveAsync(ClientWebSocket client, TaskCompletionSource<bool> readySignal, CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }

        public override void HandleEventAsync(IrcMessage payload, TaskCompletionSource<bool> readySignal)
        {

            switch (payload.Command)
            {
                case IrcCommand.ClearChat:
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

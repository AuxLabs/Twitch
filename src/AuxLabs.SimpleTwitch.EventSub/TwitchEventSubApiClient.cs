using AuxLabs.SimpleTwitch.Sockets;
using System;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class TwitchEventSubApiClient : BaseSocketClient<EventSubWebSocketPayload>
    {
        /// <summary> Triggered when the server provides a login session. </summary>
        public event Action<Session> LoggedIn;

        protected override ISerializer<EventSubWebSocketPayload> Serializer { get; }

        public Session Session { get; protected set; }

        public TwitchEventSubApiClient(TwitchEventSubConfig config = default) : base(-1, true)
        {
            config ??= new TwitchEventSubConfig();
            Serializer = config.Serializer ?? new JsonSerializer<EventSubWebSocketPayload>();
        }

        protected override void SendHeartbeat()
        {
            throw new NotImplementedException();
        }

        protected override void SendHeartbeatAck()
        {
            throw new NotImplementedException();
        }

        protected override void HandleEvent(EventSubWebSocketPayload payload, TaskCompletionSource<bool> readySignal)
        {
            switch (payload.Metadata.Type)
            {
                case MessageType.Welcome:
                    Session = payload.Payload.Session;
                    LoggedIn?.Invoke(Session);
                    break;

                case MessageType.KeepAlive:
                    break;

                case MessageType.Reconnect:
                    break;

                case MessageType.Revocation:
                    break;

                case MessageType.Notification:
                    break;

                default:
                    OnUnknownEventReceived(payload);
                    throw new TwitchException($"An unhandled event of type `{payload.Metadata.TypeRaw}` was received");
            }
        }
    }
}

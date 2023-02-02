using AuxLabs.SimpleTwitch.Sockets;
using System;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class TwitchEventSubApiClient : BaseSocketClient<EventSubWebSocketPayload>
    {
        /// <summary> Triggered when the server needs to terminate the connection. </summary>
        public event Action Reconnect;
        /// <summary> Triggered when an unhandled payload type is received. </summary>
        public event Action<EventSubWebSocketPayload> UnknownCommandReceived;

        /// <summary> Triggered when the server provides a login session. </summary>
        public event Action<Session> LoggedIn;

        protected override ISerializer<EventSubWebSocketPayload> Serializer { get; }

        private Session _session;

        public TwitchEventSubApiClient(TwitchEventSubConfig config = default) : base(-1, true)
        {
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
                    _session = payload.Payload.Session;
                    LoggedIn?.Invoke(_session);
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
                    UnknownCommandReceived?.Invoke(payload);
                    throw new TwitchException($"An unhandled event of type `{payload.Metadata.TypeRaw}` was received");
            }
        }
    }
}

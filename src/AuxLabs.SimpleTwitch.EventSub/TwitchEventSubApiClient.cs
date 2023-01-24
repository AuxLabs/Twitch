using AuxLabs.SimpleTwitch.Sockets;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class TwitchEventSubApiClient : BaseSocketClient<EventSubWebSocketPayload>
    {
        protected override ISerializer<EventSubWebSocketPayload> Serializer { get; }

        public TwitchEventSubApiClient(TwitchEventSubConfig config = default) : base(-1)
        {
            Serializer = config.Serializer ?? new JsonSerializer<EventSubWebSocketPayload>();
        }

        public override void SendIdentify(string username, string password)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}

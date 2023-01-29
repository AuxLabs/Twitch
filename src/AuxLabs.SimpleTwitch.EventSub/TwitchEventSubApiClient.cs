using AuxLabs.SimpleTwitch.Sockets;
using System;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class TwitchEventSubApiClient : BaseSocketClient<EventSubWebSocketPayload>
    {
        protected override ISerializer<EventSubWebSocketPayload> Serializer { get; }

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
            throw new NotImplementedException();
        }
    }
}

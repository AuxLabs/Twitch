using AuxLabs.SimpleTwitch.Sockets;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.PubSub
{
    public class TwitchPubSubApiClient : BaseSocketClient<PubSubPayload>
    {
        protected override ISerializer<PubSubPayload> Serializer { get; }

        public TwitchPubSubApiClient(TwitchPubSubApiConfig config = null)
            : this(TwitchConstants.PubSubUrl, config) { }
        public TwitchPubSubApiClient(string url, TwitchPubSubApiConfig config = null) : base(-1) 
        {
            config ??= new TwitchPubSubApiConfig(); 
            Serializer = config.Serializer ?? new JsonSerializer<PubSubPayload>();
        }

        protected override void SendHeartbeat()
        {
            throw new System.NotImplementedException();
        }

        protected override void SendHeartbeatAck()
        {
            throw new System.NotImplementedException();
        }

        protected override void HandleEvent(PubSubPayload payload, TaskCompletionSource<bool> readySignal)
        {
            throw new System.NotImplementedException();
        }
    }
}

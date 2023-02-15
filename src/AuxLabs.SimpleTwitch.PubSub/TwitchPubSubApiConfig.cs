using AuxLabs.SimpleTwitch.WebSockets;

namespace AuxLabs.SimpleTwitch.PubSub
{
    public class TwitchPubSubApiConfig
    {
        public ISerializer<PubSubPayload> Serializer { get; set; } = null;
    }
}

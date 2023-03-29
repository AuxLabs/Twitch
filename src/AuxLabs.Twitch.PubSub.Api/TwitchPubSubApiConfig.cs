using AuxLabs.Twitch.WebSockets;

namespace AuxLabs.Twitch.PubSub
{
    public class TwitchPubSubApiConfig
    {
        public ISerializer<PubSubPayload> Serializer { get; set; } = null;
    }
}

using AuxLabs.SimpleTwitch.Sockets;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class TwitchEventSubConfig
    {
        public ISerializer<EventSubWebSocketPayload> Serializer { get; set; } = null;
    }
}

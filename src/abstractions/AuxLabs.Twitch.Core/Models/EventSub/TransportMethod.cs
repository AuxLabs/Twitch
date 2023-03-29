using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum TransportMethod
    {
        [EnumMember(Value = "webhook")]
        Webhook,

        [EnumMember(Value = "websocket")]
        WebSocket
    }
}

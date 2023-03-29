using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum TransportMethod
    {
        [EnumMember(Value = "webhook")]
        Webhook,

        [EnumMember(Value = "websocket")]
        WebSocket
    }
}

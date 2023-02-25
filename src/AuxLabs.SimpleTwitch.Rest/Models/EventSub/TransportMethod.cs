using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum TransportMethod
    {
        [EnumMember(Value = "webhook")]
        Webhook,
        [EnumMember(Value = "websocket")]
        WebSocket
    }
}

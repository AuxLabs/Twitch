using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public enum TransportMethod
    {
        [EnumMember(Value = "webhook")]
        Webhook,
        [EnumMember(Value = "websocket")]
        WebSocket
    }
}

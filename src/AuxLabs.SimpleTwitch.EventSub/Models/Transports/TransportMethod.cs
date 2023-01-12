using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub.Models
{
    public enum TransportMethod
    {
        [EnumMember(Value = "webhook")]
        Webhook,
        [EnumMember(Value = "websocket")]
        WebSocket
    }
}

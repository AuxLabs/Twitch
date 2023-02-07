using AuxLabs.SimpleTwitch.Rest;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<TransportMethod>))]
    public enum TransportMethod
    {
        [EnumMember(Value = "webhook")]
        Webhook,
        [EnumMember(Value = "websocket")]
        WebSocket
    }
}

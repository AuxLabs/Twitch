using AuxLabs.SimpleTwitch.Sockets;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.PubSub
{
    public class PubSubPayload : PubSubPayload<PubSubResponse> { }
    public class PubSubPayload<TPayload> : IPayload
    {
        // PubSub doesn't have a hello event
        public bool IsHelloEvent => false;

        [JsonPropertyName("type")]
        public PubSubPayloadType Type { get; set; }

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("data")]
        public TPayload Data { get; set; }
    }

    public enum PubSubPayloadType
    {
        Unknown = 0,

        [EnumMember(Value = "LISTEN")]
        Listen,
        [EnumMember(Value = "UNLISTEN")]
        Unlisten,
        [EnumMember(Value = "RESPONSE")]
        Response,
        [EnumMember(Value = "MESSAGE")]
        Message
    }
}

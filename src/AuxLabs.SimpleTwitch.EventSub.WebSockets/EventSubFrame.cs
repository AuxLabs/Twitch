using AuxLabs.SimpleTwitch.WebSockets;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubFrame : IPayload
    {
        [JsonIgnore]
        public bool IsHelloEvent => Metadata.Type == MessageType.Welcome;

        /// <summary> An object that identifies the message. </summary>
        [JsonPropertyName("metadata")]
        public WebSocketMetadata Metadata { get; set; }

        /// <summary> An object that contains the message. </summary>
        [JsonPropertyName("payload")]
        public EventSubWebSocketPayload Payload { get; set; }
    }
}

using AuxLabs.SimpleTwitch.Sockets;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubWebSocketPayload : EventSubWebSocketPayload<object> { }
    public class EventSubWebSocketPayload<T> : IPayload
    {
        [JsonIgnore]
        public bool IsHelloEvent => Metadata.Type == MessageType.Welcome;

        /// <summary> An object that identifies the message. </summary>
        [JsonPropertyName("metadata")]
        public WebSocketMetadata Metadata { get; set; }

        /// <summary> An object that contains the message. </summary>
        [JsonPropertyName("payload")]
        public EventSubPayload<T> Payload { get; set; }
    }
}

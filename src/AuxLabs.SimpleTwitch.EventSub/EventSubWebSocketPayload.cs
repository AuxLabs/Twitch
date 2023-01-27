using AuxLabs.SimpleTwitch.Sockets;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubWebSocketPayload : IPayload
    {
        public bool IsHelloEvent { get; }

        /// <summary>
        /// An object that identifies the message.
        /// </summary>
        [JsonPropertyName("metadata")]
        public WebSocketMetadata Metadata { get; set; }

        /// <summary>
        /// An object that contains the message.
        /// </summary>
        [JsonPropertyName("payload")]
        public object Payload { get; set; }
    }
}

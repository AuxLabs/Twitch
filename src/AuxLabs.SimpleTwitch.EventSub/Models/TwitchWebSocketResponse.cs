namespace AuxLabs.SimpleTwitch.EventSub.Models
{
    public class TwitchWebSocketResponse<T>
    {
        /// <summary>
        /// An object that identifies the message.
        /// </summary>
        [JsonPropertyName("metadata")]
        public WebSocketMetadata Metadata { get; set; }

        /// <summary>
        /// An object that contains the message.
        /// </summary>
        [JsonPropertyName("payload")]
        public T Payload { get; set; }
    }
}

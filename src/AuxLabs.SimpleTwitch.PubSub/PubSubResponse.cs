using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.PubSub
{
    public class PubSubResponse
    {
        [JsonPropertyName("topic")]
        public PubSubTopic Topic { get; set; }

        [JsonPropertyName("message")]
        public string MessageData { get; set; }
    }
}

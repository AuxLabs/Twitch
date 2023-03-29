using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.PubSub
{
    public class PubSubResponse
    {
        [JsonPropertyName("topic")]
        public PubSubTopic Topic { get; set; }

        [JsonPropertyName("message")]
        public string MessageData { get; set; }
    }
}

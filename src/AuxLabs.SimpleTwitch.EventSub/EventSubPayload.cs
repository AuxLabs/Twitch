using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubPayload
    {
        [JsonPropertyName("challenge")]
        public string Challenge { get; set; }

        [JsonPropertyName("subscription")]
        public object Subscription { get; set; }

        [JsonPropertyName("event")]
        public object Event { get; set; }
    }
}

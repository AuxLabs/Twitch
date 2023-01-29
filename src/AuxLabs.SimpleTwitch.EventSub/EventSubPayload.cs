using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubPayload<T>
    {
        [JsonPropertyName("challenge")]
        public string Challenge { get; set; }

        [JsonPropertyName("session")]
        public Session Session { get; set; }

        [JsonPropertyName("subscription")]
        public object Subscription { get; set; }

        [JsonPropertyName("event")]
        public T Event { get; set; }
    }
}

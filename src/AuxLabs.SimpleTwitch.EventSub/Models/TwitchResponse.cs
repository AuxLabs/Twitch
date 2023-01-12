namespace AuxLabs.SimpleTwitch.EventSub.Models
{
    public class TwitchResponse
    {
        [JsonPropertyName("challenge")]
        public string Challenge { get; set; }

        [JsonPropertyName("subscription")]
        public object Subscription { get; set; }

        [JsonPropertyName("event")]
        public object Event { get; set; }
    }
}

using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    // helix/analytics/extensions
    // helix/analytics/games
    public class Analytic
    {
        [JsonProperty("extension_id")]
        public string ExtensionId { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("type")]
        public AnalyticType Type { get; set; }
        [JsonProperty("date_range")]
        public DateRange DateRange { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    // helix/analytics/extensions
    // helix/analytics/games
    public class Analytic
    {
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; }
        [JsonPropertyName("url")]
        public string URL { get; set; }
        [JsonPropertyName("type")]
        public AnalyticType Type { get; set; }
        [JsonPropertyName("date_range")]
        public DateRange DateRange { get; set; }

        [JsonConstructor]
        public Analytic(
            string extensionId, 
            string url, 
            AnalyticType analyticType, 
            DateRange dateRange)
            => (ExtensionId, URL, Type, DateRange) 
            = (extensionId, url, analyticType, dateRange);
    }
}

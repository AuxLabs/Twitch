using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public abstract class Analytic
    {
        /// <summary> The URL used to download the report. </summary>
        [JsonPropertyName("URL")]
        public string Url { get; set; }

        /// <summary> The type of report. </summary>
        [JsonPropertyName("type")]
        public AnalyticType Type { get; set; }

        /// <summary> The reporting window’s start and end dates. </summary>
        [JsonPropertyName("date_range")]
        public DateRange DateRange { get; set; }
    }
}

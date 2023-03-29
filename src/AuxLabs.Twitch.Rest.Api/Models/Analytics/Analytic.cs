using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public abstract class Analytic
    {
        /// <summary> The URL used to download the report. </summary>
        [JsonInclude, JsonPropertyName("URL")]
        public string Url { get; internal set; }

        /// <summary> The type of report. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public AnalyticType Type { get; internal set; }

        /// <summary> The reporting window’s start and end dates. </summary>
        [JsonInclude, JsonPropertyName("date_range")]
        public DateRange DateRange { get; internal set; }
    }
}

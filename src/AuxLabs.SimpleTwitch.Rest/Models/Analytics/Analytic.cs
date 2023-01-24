using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    // helix/analytics/extensions
    // helix/analytics/games
    public abstract class Analytic
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("url")]
        public string URL { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(NullableEnumStringConverter<AnalyticType>))]
        public AnalyticType Type { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("date_range")]
        public DateRange DateRange { get; }
    }
}

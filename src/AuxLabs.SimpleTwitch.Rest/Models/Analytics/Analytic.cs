using AuxLabs.SimpleTwitch.Rest.Net;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    // helix/analytics/extensions
    // helix/analytics/games
    public record class Analytic
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("url")]
        public string URL { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(NullableEnumStringConverter<AnalyticType>))]
        public AnalyticType Type { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("date_range")]
        public DateRange DateRange { get; init; } = default!;
    }
}

using AuxLabs.SimpleTwitch.Rest.Models;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetExtensionAnalyticsParams : BaseRequest
    {
        public override string[] Scopes { get; } = { "analytics:read:extensions" };

        /// <summary>
        /// Cursor for forward pagination
        /// </summary>
        [JsonPropertyName("after")]
        public string? After { get; set; }

        /// <summary>
        /// Ending date/time for returned reports
        /// </summary>
        [JsonPropertyName("ended_at")]
        public DateTime? EndedAt { get; set; }

        /// <summary>
        /// Client ID value assigned to the extension when it is created
        /// </summary>
        [JsonPropertyName("extension_id")]
        public string? ExtensionId { get; set; }

        /// <summary>
        /// Maximum number of objects to return
        /// </summary>
        [JsonPropertyName("first")]
        public int? First { get; set; }

        /// <summary>
        /// Starting date/time for returned reports
        /// </summary>
        [JsonPropertyName("started_at")]
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// Type of analytics report that is returned
        /// </summary>
        [JsonPropertyName("type")]
        public AnalyticType? Type { get; set; }

    }
}

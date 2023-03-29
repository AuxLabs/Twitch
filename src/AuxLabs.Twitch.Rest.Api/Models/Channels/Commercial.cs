using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    /// <summary> Contains information about the status of a commercial request. </summary>
    public class Commercial
    {
        /// <summary> The length of the commercial you requested. </summary>
        [JsonInclude, JsonPropertyName("length")]
        public int Length { get; internal set; }

        /// <summary> A message that indicates whether Twitch was able to serve an ad. </summary>
        [JsonInclude, JsonPropertyName("message")]
        public string Message { get; internal set; }

        /// <summary> The number of seconds you must wait before running another commercial. </summary>
        [JsonInclude, JsonPropertyName("retry_after")]
        public int RetryAfter { get; internal set; }
    }
}

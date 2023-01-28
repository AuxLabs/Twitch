using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary> Contains information about the status of a commercial request. </summary>
    public class Commercial
    {
        /// <summary> The length of the commercial you requested. </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }

        /// <summary> A message that indicates whether Twitch was able to serve an ad. </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary> The number of seconds you must wait before running another commercial. </summary>
        [JsonPropertyName("retry_after")]
        public int RetryAfter { get; set; }
    }
}

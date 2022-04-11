using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class Commercial
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("retry_after")]
        public int RetryAfter { get; init; } = default!;
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Commercial
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("retry_after")]
        public int RetryAfter { get; }
    }
}

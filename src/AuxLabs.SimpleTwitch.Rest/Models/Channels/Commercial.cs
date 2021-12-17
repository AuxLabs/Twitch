using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class Commercial
    {
        [JsonPropertyName("length")]
        public int Length { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("retry_after")]
        public int RetryAfter { get; set; }

        [JsonConstructor]
        public Commercial(int length, string msg, int retryAfter)
            => (Length, Message, RetryAfter) = (length, msg, retryAfter);
    }
}

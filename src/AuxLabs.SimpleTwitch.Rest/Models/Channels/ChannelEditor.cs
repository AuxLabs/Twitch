using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public record class ChannelEditor
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; } = default!;
    }
}

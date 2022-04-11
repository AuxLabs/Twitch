using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    // helix/bits/leaderboard
    public record class BitsUser
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("rank")]
        public int Rank { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("score")]
        public int Score { get; init; } = default!;
    }
}

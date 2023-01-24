using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    // helix/bits/leaderboard
    public class BitsUser
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("rank")]
        public int Rank { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("score")]
        public int Score { get; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary>  </summary>
    public class BitsUser
    {
        /// <summary> An ID that identifies a user on the leaderboard. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary> The user’s position on the leaderboard. </summary>
        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        /// <summary> The number of bits the user has cheered. </summary>
        [JsonPropertyName("score")]
        public int TotalBits { get; set; }
    }
}

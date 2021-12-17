using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    // helix/bits/leaderboard
    public class BitsUser
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonConstructor]
        public BitsUser(
            string userId,
            string userLogin,
            string userName,
            int rank,
            int score)
            => (UserId, UserLogin, UserName, Rank, Score) 
            = (userId, userLogin, userName, rank, score);
    }
}

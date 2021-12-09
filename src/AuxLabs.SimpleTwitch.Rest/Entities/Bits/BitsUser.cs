using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    // helix/bits/leaderboard
    public class BitsUser
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_login")]
        public string UserLogin { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
    }
}

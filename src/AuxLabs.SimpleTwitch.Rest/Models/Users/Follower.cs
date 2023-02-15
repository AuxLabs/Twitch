using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Follower : IUserFollow
    {
        [JsonPropertyName("from_id")]
        public string UserId { get; set; }

        [JsonPropertyName("from_login")]
        public string UserName { get; set; }

        [JsonPropertyName("from_name")]
        public string UserDisplayName { get; set; }

        [JsonPropertyName("to_id")]
        public string BroadcasterId { get; set; }

        [JsonPropertyName("to_login")]
        public string BroadcasterName { get; set; }

        [JsonPropertyName("to_name")]
        public string BroadcasterDisplayName { get; set; }

        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; set; }
    }
}

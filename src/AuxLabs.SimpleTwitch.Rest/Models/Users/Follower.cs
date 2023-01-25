using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Follower
    {
        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; set; }

        [JsonPropertyName("from_id")]
        public string FromId { get; set; }

        [JsonPropertyName("from_login   ")]
        public string FromLogin { get; set; }

        [JsonPropertyName("from_name")]
        public string FromName { get; set; }

        [JsonPropertyName("to_id")]
        public string ToId { get; set; }

        [JsonPropertyName("to_login")]
        public string ToLogin { get; set; }

        [JsonPropertyName("to_name")]
        public string ToName { get; set; }
    }
}

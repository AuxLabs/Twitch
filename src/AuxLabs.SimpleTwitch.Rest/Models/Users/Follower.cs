using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Follower
    {
        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; }

        [JsonPropertyName("from_id")]
        public string FromId { get; }

        [JsonPropertyName("from_login")]
        public string FromLogin { get; }

        [JsonPropertyName("from_name")]
        public string FromName { get; }

        [JsonPropertyName("to_id")]
        public string ToId { get; }

        [JsonPropertyName("to_login")]
        public string ToLogin { get; }

        [JsonPropertyName("to_name")]
        public string ToName { get; }
    }
}

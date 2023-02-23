using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class FollowedChannel
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; set; }

        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; set; }

        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; set; }
    }
}

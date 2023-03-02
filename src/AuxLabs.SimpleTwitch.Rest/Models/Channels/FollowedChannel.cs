using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class FollowedChannel
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; internal set; }

        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; internal set; }
    }
}

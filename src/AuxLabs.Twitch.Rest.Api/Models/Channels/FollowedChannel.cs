using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class FollowedChannel
    {
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        [JsonInclude, JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; internal set; }

        [JsonInclude, JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

        [JsonInclude, JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; internal set; }
    }
}

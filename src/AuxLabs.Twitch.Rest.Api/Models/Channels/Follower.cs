using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class Follower
    {
        /// <summary> An ID that uniquely identifies the user that’s following the broadcaster. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The UTC timestamp when the user started following the broadcaster. </summary>
        [JsonInclude, JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; internal set; }
    }
}

using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Follower
    {
        /// <summary> An ID that uniquely identifies the user that’s following the broadcaster. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The UTC timestamp when the user started following the broadcaster. </summary>
        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; internal set; }
    }
}

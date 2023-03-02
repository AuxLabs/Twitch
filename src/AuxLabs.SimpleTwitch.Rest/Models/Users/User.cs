using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class User : SimpleUser
    {
        /// <summary> User’s type </summary>
        [JsonInclude, JsonPropertyName("type")]
        public UserType Type { get; internal set; }

        /// <summary> User’s broadcaster type </summary>
        [JsonInclude, JsonPropertyName("broadcaster_type")]
        public BroadcasterType BroadcasterType { get; internal set; }

        /// <summary> User’s channel description </summary>
        [JsonInclude, JsonPropertyName("description")]
        public string Description { get; internal set; }

        /// <summary> URL of the user’s profile image </summary>
        [JsonInclude, JsonPropertyName("profile_image_url")]
        public string ProfileImageUrl { get; internal set; }

        /// <summary> URL of the user’s offline image </summary>
        [JsonInclude, JsonPropertyName("offline_image_url")]
        public string OfflineImageUrl { get; internal set; }

        /// <summary> Total number of views of the user’s channel </summary>
        [JsonInclude, JsonPropertyName("view_count")]
        public int ViewCount { get; internal set; }

        /// <summary> User’s verified email address </summary>
        [JsonInclude, JsonPropertyName("email")]
        public string Email { get; internal set; }

        /// <summary> Date when the user was created </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }
    }
}

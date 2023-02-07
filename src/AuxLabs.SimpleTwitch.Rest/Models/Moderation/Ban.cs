using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Ban
    {
        /// <summary> The ID of the banned user. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The banned user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The banned user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserDisplayName { get; set; }

        /// <summary> The UTC date and time of when the timeout expires </summary>
        [JsonPropertyName("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        /// <summary> The UTC date and time of when the user was banned. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> The reason the user was banned or put in a timeout if the moderator provided one. </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary> The ID of the moderator that banned the user or put them in a timeout. </summary>
        [JsonPropertyName("moderator_id")]
        public string ModeratorId { get; set; }

        /// <summary> The moderator’s login name. </summary>
        [JsonPropertyName("moderator_login")]
        public string ModeratorName { get; set; }

        /// <summary> The moderator’s display name. </summary>
        [JsonPropertyName("moderator_name")]
        public string ModeratorDisplayName { get; set; }
    }
}

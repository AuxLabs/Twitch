using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class BanEventArgs
    {
        /// <summary> The user ID for the user who was banned on the specified channel. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user login for the user who was banned on the specified channel. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The user display name for the user who was banned on the specified channel. </summary>
        [JsonPropertyName("user_name")]
        public string UserDisplayName { get; set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> The user ID of the issuer of the ban. </summary>
        [JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; set; }

        /// <summary> The user login of the issuer of the ban. </summary>
        [JsonPropertyName("moderator_user_login")]
        public string ModeratorName { get; set; }

        /// <summary> The user name of the issuer of the ban. </summary>
        [JsonPropertyName("moderator_user_name")]
        public string ModeratorDisplayName { get; set; }

        /// <summary> The reason behind the ban. </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary> The UTC date and time of when the user was banned or put in a timeout. </summary>
        [JsonPropertyName("banned_at")]
        public DateTime BannedAt { get; set; }

        /// <summary> The UTC date and time of when the timeout ends. </summary>
        [JsonPropertyName("ends_at")]
        public DateTime? EndsAt { get; set; }

        /// <summary> Indicates whether the ban is permanent. </summary>
        [JsonPropertyName("is_permanent")]
        public bool IsPermanent { get; set; }
    }
}

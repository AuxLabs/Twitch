using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class BanEventArgs
    {
        /// <summary> The user ID for the user who was banned on the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user login for the user who was banned on the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user display name for the user who was banned on the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> The user ID of the issuer of the ban. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; internal set; }

        /// <summary> The user login of the issuer of the ban. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_login")]
        public string ModeratorName { get; internal set; }

        /// <summary> The user name of the issuer of the ban. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_name")]
        public string ModeratorDisplayName { get; internal set; }

        /// <summary> The reason behind the ban. </summary>
        [JsonInclude, JsonPropertyName("reason")]
        public string Reason { get; internal set; }

        /// <summary> The UTC date and time of when the user was banned or put in a timeout. </summary>
        [JsonInclude, JsonPropertyName("banned_at")]
        public DateTime BannedAt { get; internal set; }

        /// <summary> The UTC date and time of when the timeout ends. </summary>
        [JsonInclude, JsonPropertyName("ends_at")]
        public DateTime? EndsAt { get; internal set; }

        /// <summary> Indicates whether the ban is permanent. </summary>
        [JsonInclude, JsonPropertyName("is_permanent")]
        public bool IsPermanent { get; internal set; }
    }
}

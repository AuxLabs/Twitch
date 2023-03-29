﻿using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class BannedUser
    {
        /// <summary> The ID of the banned user. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The banned user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The banned user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The UTC date and time of when the timeout expires </summary>
        [JsonInclude, JsonPropertyName("expires_at")]
        public DateTime? ExpiresAt { get; internal set; }

        /// <summary> The UTC date and time of when the user was banned. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary> The reason the user was banned or put in a timeout if the moderator provided one. </summary>
        [JsonInclude, JsonPropertyName("reason")]
        public string Reason { get; internal set; }

        /// <summary> The ID of the moderator that banned the user or put them in a timeout. </summary>
        [JsonInclude, JsonPropertyName("moderator_id")]
        public string ModeratorId { get; internal set; }

        /// <summary> The moderator’s login name. </summary>
        [JsonInclude, JsonPropertyName("moderator_login")]
        public string ModeratorName { get; internal set; }

        /// <summary> The moderator’s display name. </summary>
        [JsonInclude, JsonPropertyName("moderator_name")]
        public string ModeratorDisplayName { get; internal set; }
    }
}

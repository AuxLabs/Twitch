using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class UnbanEventArgs
    {
        /// <summary> The user id for the user who was unbanned on the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user login for the user who was unbanned on the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user display name for the user who was unbanned on the specified channel. </summary>
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

        /// <summary> The user ID of the issuer of the unban. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; internal set; }

        /// <summary> The user login of the issuer of the unban. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_login")]
        public string ModeratorName { get; internal set; }

        /// <summary> The user name of the issuer of the unban. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_name")]
        public string ModeratorDisplayName { get; internal set; }

    }
}

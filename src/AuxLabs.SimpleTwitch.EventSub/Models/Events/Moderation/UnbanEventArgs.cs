using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class UnbanEventArgs
    {
        /// <summary> The user id for the user who was unbanned on the specified channel. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user login for the user who was unbanned on the specified channel. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The user display name for the user who was unbanned on the specified channel. </summary>
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

        /// <summary> The user ID of the issuer of the unban. </summary>
        [JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; set; }

        /// <summary> The user login of the issuer of the unban. </summary>
        [JsonPropertyName("moderator_user_login")]
        public string ModeratorName { get; set; }

        /// <summary> The user name of the issuer of the unban. </summary>
        [JsonPropertyName("moderator_user_name")]
        public string ModeratorDisplayName { get; set; }

    }
}

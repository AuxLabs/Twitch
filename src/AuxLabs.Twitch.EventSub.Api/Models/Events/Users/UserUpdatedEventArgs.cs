using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class UserUpdatedEventArgs
    {
        /// <summary> The user’s user id. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s user login. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user’s user display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The user’s email address. </summary>
        [JsonInclude, JsonPropertyName("email")]
        public string UserEmail { get; internal set; }

        /// <summary> Determines whether Twitch has verified the user’s email address. </summary>
        [JsonInclude, JsonPropertyName("email_verified")]
        public bool IsEmailVerified { get; internal set; }

        /// <summary> The user’s description. </summary>
        [JsonInclude, JsonPropertyName("description")]
        public string Description { get; internal set; }
    }
}

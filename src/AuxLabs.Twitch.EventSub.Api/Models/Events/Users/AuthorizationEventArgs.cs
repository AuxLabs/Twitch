using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class AuthorizationEventArgs
    {
        /// <summary> The client_id of the application that was granted user access. </summary>
        [JsonInclude, JsonPropertyName("client_id")]
        public string ClientId { get; internal set; }

        /// <summary> The user id for the user who has granted authorization for your client id. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user login for the user who has granted authorization for your client id. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user display name for the user who has granted authorization for your client id. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }
    }
}

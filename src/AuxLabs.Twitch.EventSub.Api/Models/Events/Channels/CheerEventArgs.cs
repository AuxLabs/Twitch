using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class CheerEventArgs
    {
        /// <summary> Whether the user cheered anonymously or not. </summary>
        [JsonInclude, JsonPropertyName("is_anonymous")]
        public bool IsAnonymous { get; internal set; }

        /// <summary> The user ID for the user who cheered on the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user login for the user who cheered on the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user display name for the user who cheered on the specified channel. </summary>
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

        /// <summary> The message sent with the cheer. </summary>
        [JsonInclude, JsonPropertyName("message")]
        public string Message { get; internal set; }

        /// <summary> The number of bits cheered. </summary>
        [JsonInclude, JsonPropertyName("bits")]
        public int BitsAmount { get; internal set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class CheerEventArgs
    {
        /// <summary> Whether the user cheered anonymously or not. </summary>
        [JsonPropertyName("is_anonymous")]
        public bool IsAnonymous { get; set; }

        /// <summary> The user ID for the user who cheered on the specified channel. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user login for the user who cheered on the specified channel. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The user display name for the user who cheered on the specified channel. </summary>
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

        /// <summary> The message sent with the cheer. </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary> The number of bits cheered. </summary>
        [JsonPropertyName("bits")]
        public int BitsAmount { get; set; }
    }
}

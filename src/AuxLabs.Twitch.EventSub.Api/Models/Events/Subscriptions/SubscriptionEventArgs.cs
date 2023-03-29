using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class SubscriptionEventArgs
    {
        /// <summary> The user ID for the user who subscribed to the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user login for the user who subscribed to the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user display name for the user who subscribed to the specified channel. </summary>
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

        /// <summary> The tier of the subscription. </summary>
        [JsonInclude, JsonPropertyName("tier")]
        public SubscriptionType Tier { get; internal set; }

        /// <summary> Whether the subscription is a gift. </summary>
        [JsonInclude, JsonPropertyName("is_gift")]
        public bool IsGift { get; internal set; }
    }
}

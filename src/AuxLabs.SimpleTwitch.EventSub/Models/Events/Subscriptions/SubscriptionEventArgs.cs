using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class SubscriptionEventArgs
    {
        /// <summary> The user ID for the user who subscribed to the specified channel. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user login for the user who subscribed to the specified channel. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The user display name for the user who subscribed to the specified channel. </summary>
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

        /// <summary> The tier of the subscription. </summary>
        [JsonPropertyName("tier")]
        public SubscriptionType Tier { get; set; }

        /// <summary> Whether the subscription is a gift. </summary>
        [JsonPropertyName("is_gift")]
        public bool IsGift { get; set; }
    }
}

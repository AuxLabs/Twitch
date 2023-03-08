using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class SubscriptionMessageEventArgs : SubscriptionEventArgs
    {
        /// <summary> An object that contains the resubscription message and emote information needed to recreate the message. </summary>
        [JsonInclude, JsonPropertyName("message")]
        public SubscriptionMessage Message { get; internal set; }

        /// <summary> The total number of months the user has been subscribed to the channel. </summary>
        [JsonInclude, JsonPropertyName("cumulative_months")]
        public int CumulativeMonths { get; internal set; }

        /// <summary> The number of consecutive months the user’s current subscription has been active. </summary>
        /// <remarks> This value is <c>null</c> if the user has opted out of sharing this information. </remarks>
        [JsonInclude, JsonPropertyName("streak_months")]
        public int? StreakMonths { get; internal set; }

        /// <summary> The month duration of the subscription. </summary>
        [JsonInclude, JsonPropertyName("duration_months")]
        public int DurationMonths { get; internal set; }
    }
}

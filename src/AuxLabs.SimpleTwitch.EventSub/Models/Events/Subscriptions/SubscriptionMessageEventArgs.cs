using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class SubscriptionMessageEventArgs : SubscriptionEventArgs
    {
        /// <summary> An object that contains the resubscription message and emote information needed to recreate the message. </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary> The total number of months the user has been subscribed to the channel. </summary>
        [JsonPropertyName("cumulative_months")]
        public int CumulativeMonths { get; set; }

        /// <summary> The number of consecutive months the user’s current subscription has been active. </summary>
        /// <remarks> This value is <c>null</c> if the user has opted out of sharing this information. </remarks>
        [JsonPropertyName("streak_months")]
        public int? StreakMonths { get; set; }

        /// <summary> The month duration of the subscription. </summary>
        [JsonPropertyName("duration_months")]
        public int DurationMonths { get; set; }
    }
}

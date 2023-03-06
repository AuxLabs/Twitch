using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class SubscriptionGiftedEventArgs : SubscriptionEventArgs
    {
        /// <summary> The number of subscriptions gifted by this user in the channel. </summary>
        /// <remarks> This value is <c>null</c> for anonymous gifts or if the gifter has opted out of sharing this information. </remarks>
        [JsonPropertyName("cumulative_total")]
        public int? CumulativeTotal { get; set; }

        /// <summary> Whether the subscription gift was anonymous. </summary>
        [JsonPropertyName("is_anonymous")]
        public bool IsAnonymous { get; set; }
    }
}

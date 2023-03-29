using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class SubscriptionGiftedEventArgs : SubscriptionEventArgs
    {
        /// <summary> The number of subscriptions gifted by this user in the channel. </summary>
        /// <remarks> This value is <c>null</c> for anonymous gifts or if the gifter has opted out of sharing this information. </remarks>
        [JsonInclude, JsonPropertyName("cumulative_total")]
        public int? CumulativeTotal { get; internal set; }

        /// <summary> Whether the subscription gift was anonymous. </summary>
        [JsonInclude, JsonPropertyName("is_anonymous")]
        public bool IsAnonymous { get; internal set; }
    }
}

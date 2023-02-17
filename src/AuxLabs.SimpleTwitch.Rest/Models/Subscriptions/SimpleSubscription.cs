using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class SimpleSubscription
    {
        /// <summary>  </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary>  </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; set; }

        /// <summary>  </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary>  </summary>
        [JsonPropertyName("gifter_id")]
        public string GifterId { get; set; }

        /// <summary>  </summary>
        [JsonPropertyName("gifter_login")]
        public string GifterName { get; set; }

        /// <summary>  </summary>
        [JsonPropertyName("gifter_name")]
        public string GifterDisplayName { get; set; }

        /// <summary> Determines whether the subscription is a gift subscription. </summary>
        [JsonPropertyName("is_gift")]
        public bool IsGift { get; set; }

        /// <summary> The type of subscription. </summary>
        [JsonPropertyName("tier")]
        public SubscriptionType Tier { get; set; }
    }
}

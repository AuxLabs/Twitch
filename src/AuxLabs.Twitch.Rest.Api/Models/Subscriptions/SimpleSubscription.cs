using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class SimpleSubscription
    {
        /// <summary>  </summary>
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary>  </summary>
        [JsonInclude, JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary>  </summary>
        [JsonInclude, JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary>  </summary>
        [JsonInclude, JsonPropertyName("gifter_id")]
        public string GifterId { get; internal set; }

        /// <summary>  </summary>
        [JsonInclude, JsonPropertyName("gifter_login")]
        public string GifterName { get; internal set; }

        /// <summary>  </summary>
        [JsonInclude, JsonPropertyName("gifter_name")]
        public string GifterDisplayName { get; internal set; }

        /// <summary> Determines whether the subscription is a gift subscription. </summary>
        [JsonInclude, JsonPropertyName("is_gift")]
        public bool IsGift { get; internal set; }

        /// <summary> The type of subscription. </summary>
        [JsonInclude, JsonPropertyName("tier")]
        public SubscriptionType Tier { get; internal set; }
    }
}

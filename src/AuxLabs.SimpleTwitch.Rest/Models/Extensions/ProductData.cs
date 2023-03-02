using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ProductData
    {
        /// <summary> An ID that identifies the digital product. </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; internal set; }

        /// <summary> Set to <c>twitch.ext.</c> + <c>the extension's ID</c>. </summary>
        [JsonPropertyName("domain")]
        public string Domain { get; internal set; }

        /// <summary> Contains details about the digital product’s cost. </summary>
        [JsonPropertyName("cost")]
        public Cost Cost { get; internal set; }

        /// <summary> Determines whether the product is in development. </summary>
        [JsonPropertyName("inDevelopment")]
        public bool IsInDevelopment { get; internal set; }

        /// <summary> The name of the digital product. </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; internal set; }

        /// <summary> This is always null since you may purchase only unexpired products. </summary>
        [JsonPropertyName("expiration")]
        public DateTime? ExpiresAt { get; internal set; }

        /// <summary> Determines whether the data was broadcast to all instances of the extension. </summary>
        [JsonPropertyName("broadcast")]
        public bool IsBroadcast { get; internal set; }
    }
}

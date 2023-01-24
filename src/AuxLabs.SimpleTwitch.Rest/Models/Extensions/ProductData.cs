using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ProductData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("domain")]
        public string Domain { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cost")]
        public Cost Cost { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("in_development")]
        public bool InDevelopment { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("expiration")]
        public DateTime? ExpiresAt { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcast")]
        public bool IsBroadcast { get; }
    }
}

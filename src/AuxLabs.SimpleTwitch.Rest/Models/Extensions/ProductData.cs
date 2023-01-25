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
        public string Domain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cost")]
        public Cost Cost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("in_development")]
        public bool InDevelopment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("expiration")]
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcast")]
        public bool IsBroadcast { get; set; }
    }
}

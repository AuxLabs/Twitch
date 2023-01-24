using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ProductData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("domain")]
        public string Domain { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cost")]
        public Cost Cost { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("in_development")]
        public bool InDevelopment { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("expiration")]
        public DateTime? ExpiresAt { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcast")]
        public bool IsBroadcast { get; init; }
    }
}

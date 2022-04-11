using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class ProductData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("domain")]
        public string Domain { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cost")]
        public Cost Cost { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("in_development")]
        public bool InDevelopment { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("expiration")]
        public DateTime? ExpiresAt { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcast")]
        public bool IsBroadcast { get; init; } = default!;
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class ProductData
    {
        [JsonPropertyName("domain")]
        public string Domain { get; set; }
        [JsonPropertyName("sku")]
        public string Sku { get; set; }
        [JsonPropertyName("cost")]
        public Cost Cost { get; set; }
        [JsonPropertyName("in_development")]
        public bool InDevelopment { get; set; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        [JsonPropertyName("expiration")]
        public DateTime? ExpiresAt { get; set; }
        [JsonPropertyName("broadcast")]
        public bool IsBroadcast { get; set; }

        [JsonConstructor]
        public ProductData(
            string domain, 
            string sku, 
            Cost cost, 
            bool inDev, 
            string displayName, 
            DateTime? expiresAt, 
            bool isBroadcast)
            => (Domain, Sku, Cost, InDevelopment, DisplayName, ExpiresAt, IsBroadcast)
            = (domain, sku, cost, inDev, displayName, expiresAt, isBroadcast);
    }
}

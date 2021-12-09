using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public class ProductData
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("sku")]
        public string Sku { get; set; }
        [JsonProperty("cost")]
        public Cost Cost { get; set; }
        [JsonProperty("in_development")]
        public bool InDevelopment { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("expiration")]
        public DateTime? ExpiresAt { get; set; }
        [JsonProperty("broadcast")]
        public bool IsBroadcast { get; set; }
    }
}

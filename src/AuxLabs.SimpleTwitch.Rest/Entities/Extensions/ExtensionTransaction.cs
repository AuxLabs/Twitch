using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    // helix/extensions/transactions
    public class ExtensionTransaction
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonProperty("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonProperty("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_login")]
        public string UserLogin { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("product_type")]
        public ProductType ProductType { get; set; }
        [JsonProperty("product_data")]
        public ProductData ProductData { get; set; }
    }
}

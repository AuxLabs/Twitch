using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    // helix/extensions/transactions
    public class ExtensionTransaction
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("product_type")]
        [JsonConverter(typeof(NullableEnumStringConverter<ProductType>))]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("product_data")]
        public ProductData ProductData { get; set; }
    }
}

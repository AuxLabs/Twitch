using AuxLabs.SimpleTwitch.Rest;
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
        public string Id { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("product_type")]
        [JsonConverter(typeof(NullableEnumStringConverter<ProductType>))]
        public ProductType ProductType { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("product_data")]
        public ProductData ProductData { get; init; }
    }
}

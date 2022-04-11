using AuxLabs.SimpleTwitch.Rest.Net;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    // helix/extensions/transactions
    public record class ExtensionTransaction
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("product_type")]
        [JsonConverter(typeof(NullableEnumStringConverter<ProductType>))]
        public ProductType ProductType { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("product_data")]
        public ProductData ProductData { get; init; } = default!;
    }
}

using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ExtensionTransaction
    {
        /// <summary> An ID that identifies the transaction. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The UTC date and time of the transaction. </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary> The ID of the broadcaster that owns the channel where the transaction occurred. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        /// <summary> The ID of the user that purchased the digital product. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary> The type of transaction. </summary>
        [JsonPropertyName("product_type")]
        [JsonConverter(typeof(NullableEnumStringConverter<ProductType>))]
        public ProductType ProductType { get; set; }

        /// <summary> Contains details about the digital product. </summary>
        [JsonPropertyName("product_data")]
        public ProductData ProductData { get; set; }
    }
}

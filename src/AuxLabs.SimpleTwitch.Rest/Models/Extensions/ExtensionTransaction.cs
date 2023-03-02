using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ExtensionTransaction
    {
        /// <summary> An ID that identifies the transaction. </summary>
        [JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The UTC date and time of the transaction. </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; internal set; }

        /// <summary> The ID of the broadcaster that owns the channel where the transaction occurred. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> The ID of the user that purchased the digital product. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The type of transaction. </summary>
        [JsonPropertyName("product_type")]
        public ProductType ProductType { get; internal set; }

        /// <summary> Contains details about the digital product. </summary>
        [JsonPropertyName("product_data")]
        public ProductData ProductData { get; internal set; }
    }
}

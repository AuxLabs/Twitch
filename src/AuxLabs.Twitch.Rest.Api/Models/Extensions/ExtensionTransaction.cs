using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class ExtensionTransaction
    {
        /// <summary> An ID that identifies the transaction. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The UTC date and time of the transaction. </summary>
        [JsonInclude, JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; internal set; }

        /// <summary> The ID of the broadcaster that owns the channel where the transaction occurred. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> The ID of the user that purchased the digital product. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The type of transaction. </summary>
        [JsonInclude, JsonPropertyName("product_type")]
        public ProductType ProductType { get; internal set; }

        /// <summary> Contains details about the digital product. </summary>
        [JsonInclude, JsonPropertyName("product_data")]
        public ProductData ProductData { get; internal set; }
    }
}

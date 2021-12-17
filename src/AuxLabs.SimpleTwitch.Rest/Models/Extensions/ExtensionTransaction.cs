using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    // helix/extensions/transactions
    public class ExtensionTransaction
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("product_type")]
        public ProductType ProductType { get; set; }
        [JsonPropertyName("product_data")]
        public ProductData ProductData { get; set; }

        [JsonConstructor]
        public ExtensionTransaction(
            string id,
            DateTime timestamp,
            string broadcasterId,
            string broadcasterLogin,
            string broadcasterName,
            string userId,
            string userLogin,
            string userName,
            ProductType productType,
            ProductData productData)
            => (Id, Timestamp, BroadcasterId, BroadcasterLogin, BroadcasterName, UserId, UserLogin, UserName, ProductType, ProductData)
            = (id, timestamp, broadcasterId, broadcasterLogin, broadcasterName, userId, userLogin, userName, productType, productData);
    }
}

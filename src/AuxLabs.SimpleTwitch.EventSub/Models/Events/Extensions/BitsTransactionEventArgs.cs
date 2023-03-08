using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class BitsTransactionEventArgs
    {
        /// <summary> Client ID of the extension. </summary>
        [JsonInclude, JsonPropertyName("extension_client_id")]
        public string ClientId { get; internal set; }

        /// <summary> Transaction ID. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The transaction’s broadcaster ID. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The transaction’s broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The transaction’s broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> The transaction’s user ID. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The transaction’s user login. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The transaction’s user display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> Additional extension product information. </summary>
        [JsonInclude, JsonPropertyName("product")]
        public BitsProduct Product { get; internal set; }
    }
}

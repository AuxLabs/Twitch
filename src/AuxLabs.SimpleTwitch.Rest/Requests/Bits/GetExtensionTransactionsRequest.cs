using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetExtensionTransactionsRequest :BaseRequest
    {
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("first")]
        public int First { get; set; }

        [JsonPropertyName("after")]
        public string After { get; set; }
    }
}

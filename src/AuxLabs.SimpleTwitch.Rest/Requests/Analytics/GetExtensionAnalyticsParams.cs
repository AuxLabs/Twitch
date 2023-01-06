using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetExtensionAnalyticsParams : GetAnalyticsParams
    {
        public override string[] Scopes { get; } = { "analytics:read:extensions" };

        /// <summary>
        /// Client ID value assigned to the extension when it is created
        /// </summary>
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ExtensionTransactionCondition
    {
        /// <summary> The client ID of the extension. </summary>
        [JsonPropertyName("extension_client_id")]
        public string ExtensionClientId { get; set; }

        public ExtensionTransactionCondition() { }
        public ExtensionTransactionCondition(string extesionClientId)
        {
            ExtensionClientId = extesionClientId;
        }
    }
}

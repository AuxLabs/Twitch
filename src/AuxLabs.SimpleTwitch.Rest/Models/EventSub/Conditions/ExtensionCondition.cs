using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ExtensionCondition : IEventCondition
    {
        /// <summary> The client ID of the extension. </summary>
        [JsonInclude, JsonPropertyName("extension_client_id")]
        public string ClientId { get; internal set; }

        public ExtensionCondition(string clientId)
        {
            Require.NotNullOrWhitespace(clientId, nameof(clientId));

            ClientId = clientId;
        }

        public static implicit operator string(ExtensionCondition value) => value.ClientId;
        public static implicit operator ExtensionCondition(string v) => new ExtensionCondition(v);
    }
}

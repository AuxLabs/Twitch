using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary> Contains information about an extension's analytic report. </summary>
    public class ExtensionAnalytic : Analytic
    {
        public static string[] Scopes = new[] { "analytics:read:extensions" };

        /// <summary> An ID that identifies the extension that the report was generated for. </summary>
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; }
    }
}

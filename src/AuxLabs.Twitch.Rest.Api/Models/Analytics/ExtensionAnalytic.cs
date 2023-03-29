using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    /// <summary> Contains information about an extension's analytic report. </summary>
    public class ExtensionAnalytic : Analytic
    {
        /// <summary> An ID that identifies the extension that the report was generated for. </summary>
        [JsonInclude, JsonPropertyName("extension_id")]
        public string ExtensionId { get; internal set; }
    }
}

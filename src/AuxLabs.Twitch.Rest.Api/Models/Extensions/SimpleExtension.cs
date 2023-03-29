using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class SimpleExtension
    {
        /// <summary> An ID that identifies the extension. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The extension’s version. </summary>
        [JsonInclude, JsonPropertyName("version")]
        public string Version { get; internal set; }

        /// <summary> The extension’s name. </summary>
        [JsonInclude, JsonPropertyName("name")]
        public string Name { get; internal set; }

        /// <summary> Determines the extension’s activation state. </summary>
        [JsonInclude, JsonPropertyName("active")]
        public bool? IsActive { get; internal set; }
    }
}

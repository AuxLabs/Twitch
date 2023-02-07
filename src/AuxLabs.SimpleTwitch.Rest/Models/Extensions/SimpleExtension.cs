using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class SimpleExtension
    {
        /// <summary> An ID that identifies the extension. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The extension’s version. </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary> The extension’s name. </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary> Determines the extension’s activation state. </summary>
        [JsonPropertyName("active")]
        public bool? IsActive { get; set; }
    }
}

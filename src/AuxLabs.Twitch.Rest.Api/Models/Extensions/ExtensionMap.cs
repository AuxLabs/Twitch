using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class ExtensionMap
    {
        /// <summary> A dictionary that contains the data for a panel extension. </summary>
        [JsonInclude, JsonPropertyName("panel")]
        public IReadOnlyDictionary<string, SimpleExtension> Panel { get; internal set; }

        /// <summary> A dictionary that contains the data for a video-overlay extension. </summary>
        [JsonInclude, JsonPropertyName("overlay")]
        public IReadOnlyDictionary<string, SimpleExtension> Overlay { get; internal set; }

        /// <summary> A dictionary that contains the data for a video-component extension. </summary>
        [JsonInclude, JsonPropertyName("component")]
        public IReadOnlyDictionary<string, ComponentExtension> Component { get; internal set; }
    }
}

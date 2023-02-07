using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ExtensionMap
    {
        /// <summary> A dictionary that contains the data for a panel extension. </summary>
        [JsonPropertyName("panel")]
        public IReadOnlyDictionary<string, SimpleExtension> Panel { get; set; }

        /// <summary> A dictionary that contains the data for a video-overlay extension. </summary>
        [JsonPropertyName("overlay")]
        public IReadOnlyDictionary<string, SimpleExtension> Overlay { get; set; }

        /// <summary> A dictionary that contains the data for a video-component extension. </summary>
        [JsonPropertyName("component")]
        public IReadOnlyDictionary<string, ComponentExtension> Component { get; set; }
    }
}

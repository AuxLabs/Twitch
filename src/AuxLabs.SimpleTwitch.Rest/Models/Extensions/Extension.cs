using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Extension : SimpleExtension
    {
        /// <summary> Determines whether the extension is configured and can be activated. </summary>
        [JsonPropertyName("can_activate")]
        public bool CanActivate { get; internal set; }

        /// <summary> The extension types that you can activate for this extension. </summary>
        [JsonPropertyName("type")]
        public IReadOnlyCollection<ExtensionType> Types { get; internal set; }
    }
}

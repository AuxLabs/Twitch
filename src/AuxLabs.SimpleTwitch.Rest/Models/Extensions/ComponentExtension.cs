using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ComponentExtension : SimpleExtension
    {
        /// <summary> The x-coordinate where the extension is placed. </summary>
        [JsonInclude, JsonPropertyName("x")]
        public string X { get; internal set; }

        /// <summary> The y-coordinate where the extension is placed. </summary>
        [JsonInclude, JsonPropertyName("y")]
        public string Y { get; internal set; }
    }
}

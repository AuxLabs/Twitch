using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheermoteTheme
    {
        [JsonInclude, JsonPropertyName("dark")]
        public CheermoteFormat Dark { get; internal set; }

        [JsonInclude, JsonPropertyName("light")]
        public CheermoteFormat Light { get; internal set; }
    }
}

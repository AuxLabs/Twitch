using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheermoteTheme
    {
        [JsonPropertyName("dark")]
        public CheermoteFormat Dark { get; internal set; }

        [JsonPropertyName("light")]
        public CheermoteFormat Light { get; internal set; }
    }
}

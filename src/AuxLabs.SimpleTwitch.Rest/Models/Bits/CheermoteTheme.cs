using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheermoteTheme
    {
        [JsonPropertyName("dark")]
        public CheermoteFormat Dark { get; set; }

        [JsonPropertyName("light")]
        public CheermoteFormat Light { get; set; }
    }
}

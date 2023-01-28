using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EmoteTheme
    {
        [JsonPropertyName("dark")]
        public EmoteFormat Dark { get; set; }

        [JsonPropertyName("light")]
        public EmoteFormat Light { get; set; }
    }
}

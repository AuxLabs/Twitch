using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class CheermoteTheme
    {
        [JsonInclude, JsonPropertyName("dark")]
        public CheermoteFormat Dark { get; internal set; }

        [JsonInclude, JsonPropertyName("light")]
        public CheermoteFormat Light { get; internal set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class CheermoteTheme
    {
        [JsonInclude, JsonPropertyName("dark")]
        public CheermoteFormat Dark { get; internal set; }

        [JsonInclude, JsonPropertyName("light")]
        public CheermoteFormat Light { get; internal set; }
    }
}

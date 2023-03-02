using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheermoteFormat
    {
        [JsonInclude, JsonPropertyName("animated")]
        public CheermoteImage AnimatedImage { get; internal set; }

        [JsonInclude, JsonPropertyName("static")]
        public CheermoteImage StaticImage { get; internal set; }
    }
}

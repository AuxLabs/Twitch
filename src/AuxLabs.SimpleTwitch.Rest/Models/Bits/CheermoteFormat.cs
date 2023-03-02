using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheermoteFormat
    {
        [JsonPropertyName("animated")]
        public CheermoteImage AnimatedImage { get; internal set; }

        [JsonPropertyName("static")]
        public CheermoteImage StaticImage { get; internal set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheermoteFormat
    {
        [JsonPropertyName("animated")]
        public CheermoteImage AnimatedImage { get; set; }

        [JsonPropertyName("static")]
        public CheermoteImage StaticImage { get; set; }
    }
}

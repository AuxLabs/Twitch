using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EmoteFormat
    {
        [JsonPropertyName("animated")]
        public EmoteImage AnimatedImage { get; set; }

        [JsonPropertyName("static")]
        public EmoteImage StaticImage { get; set; }
    }
}

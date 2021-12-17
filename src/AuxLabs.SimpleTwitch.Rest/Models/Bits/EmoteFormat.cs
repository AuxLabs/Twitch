using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class EmoteFormat
    {
        [JsonPropertyName("animated")]
        public EmoteImage AnimatedImage { get; set; }
        [JsonPropertyName("static")]
        public EmoteImage StaticImage { get; set; }

        [JsonConstructor]
        public EmoteFormat(EmoteImage animatedImage, EmoteImage staticImage)
            => (AnimatedImage, StaticImage) = (animatedImage, staticImage);
    }
}

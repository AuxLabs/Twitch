using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class CheermoteFormat
    {
        [JsonInclude, JsonPropertyName("animated")]
        public CheermoteImage AnimatedImage { get; internal set; }

        [JsonInclude, JsonPropertyName("static")]
        public CheermoteImage StaticImage { get; internal set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class EmoteFormat
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("animated")]
        public EmoteImage AnimatedImage { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("static")]
        public EmoteImage StaticImage { get; init; } = default!;
    }
}

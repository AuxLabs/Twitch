using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EmoteFormat
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("animated")]
        public EmoteImage AnimatedImage { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("static")]
        public EmoteImage StaticImage { get; init; }
    }
}

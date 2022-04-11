using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class EmoteTheme
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("dark")]
        public EmoteFormat Dark { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("light")]
        public EmoteFormat Light { get; init; } = default!;
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EmoteTheme
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("dark")]
        public EmoteFormat Dark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("light")]
        public EmoteFormat Light { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EmoteImage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("1")]
        public string Size1 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("1.5")]
        public string Size15 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("1")]
        public string Size2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("2")]
        public string Size3 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("4")]
        public string Size4 { get; init; }
    }
}

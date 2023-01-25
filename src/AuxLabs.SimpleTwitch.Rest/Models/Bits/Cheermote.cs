using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Cheermote
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("min_bits")]
        public int MinimumBits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("images")]
        public EmoteTheme Images { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("can_cheer")]
        public bool CanCheer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; set; }
    }
}

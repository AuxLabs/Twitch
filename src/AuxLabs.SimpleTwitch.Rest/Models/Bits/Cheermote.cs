using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Cheermote
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("min_bits")]
        public int MinimumBits { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("images")]
        public EmoteTheme Images { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("can_cheer")]
        public bool CanCheer { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; }
    }
}

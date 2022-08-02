using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public record class Cheermote
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("min_bits")]
        public int MinimumBits { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("images")]
        public EmoteTheme Images { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("can_cheer")]
        public bool CanCheer { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; init; }
    }
}

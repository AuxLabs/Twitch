using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class BitsTier
    {
        /// <summary> The minimum number of Bits that you must cheer at this tier level. </summary>
        [JsonPropertyName("min_bits")]
        public int MinimumBits { get; set; }

        /// <summary> The tier level. </summary>
        [JsonPropertyName("id")]
        public string Level { get; set; }

        /// <summary> The hex code of the color associated with this tier level </summary>
        [JsonPropertyName("color")]
        public Color Color { get; set; }

        /// <summary> Determines whether users can cheer at this tier level. </summary>
        [JsonPropertyName("can_cheer")]
        public bool CanCheer { get; set; }

        /// <summary> Determines whether this tier level is shown in the Bits card. </summary>
        [JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; set; }

        /// <summary> The animated and static image sets for the Cheermote. </summary>
        [JsonPropertyName("images")]
        public CheermoteTheme Images { get; set; }
    }
}

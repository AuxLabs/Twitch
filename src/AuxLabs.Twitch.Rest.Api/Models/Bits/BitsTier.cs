using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class BitsTier
    {
        /// <summary> The minimum number of Bits that you must cheer at this tier level. </summary>
        [JsonInclude, JsonPropertyName("min_bits")]
        public int MinimumBits { get; internal set; }

        /// <summary> The tier level. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Level { get; internal set; }

        /// <summary> The hex code of the color associated with this tier level </summary>
        [JsonInclude, JsonPropertyName("color")]
        public Color Color { get; internal set; }

        /// <summary> Determines whether users can cheer at this tier level. </summary>
        [JsonInclude, JsonPropertyName("can_cheer")]
        public bool CanCheer { get; internal set; }

        /// <summary> Determines whether this tier level is shown in the Bits card. </summary>
        [JsonInclude, JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; internal set; }

        /// <summary> The animated and static image sets for the Cheermote. </summary>
        [JsonInclude, JsonPropertyName("images")]
        public CheermoteTheme Images { get; internal set; }
    }
}

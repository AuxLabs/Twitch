using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Cheermote
    {
        /// <summary> The prefix of the Cheermote string that you use in chat to cheer bits. </summary>
        [JsonPropertyName("prefix")]
        public string Name { get; set; }

        /// <summary> A collection of tier levels that the Cheermote supports. </summary>
        [JsonPropertyName("tiers")]
        public IEnumerable<BitsTier> Tiers { get; set; }

        /// <summary> The type of Cheermote. </summary>
        [JsonPropertyName("type")]
        public CheermoteType Type { get; set; }

        /// <summary> The order that the Cheermotes are shown in the bits card. </summary>
        [JsonPropertyName("order")]
        public int Order { get; set; }

        /// <summary> The date and time when this Cheermote was last updated. </summary>
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdatedAt { get; set; }

        /// <summary> Indicates whether this Cheermote provides a charitable contribution match during charity campaigns. </summary>
        [JsonPropertyName("is_charitable")]
        public bool IsCharitable { get; set; }
    }
}

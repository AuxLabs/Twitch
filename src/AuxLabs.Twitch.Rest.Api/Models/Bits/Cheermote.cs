using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class Cheermote
    {
        /// <summary> The prefix of the Cheermote string that you use in chat to cheer bits. </summary>
        [JsonInclude, JsonPropertyName("prefix")]
        public string Name { get; internal set; }

        /// <summary> A collection of tier levels that the Cheermote supports. </summary>
        [JsonInclude, JsonPropertyName("tiers")]
        public IEnumerable<BitsTier> Tiers { get; internal set; }

        /// <summary> The type of Cheermote. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public CheermoteType Type { get; internal set; }

        /// <summary> The order that the Cheermotes are shown in the bits card. </summary>
        [JsonInclude, JsonPropertyName("order")]
        public int Order { get; internal set; }

        /// <summary> The date and time when this Cheermote was last updated. </summary>
        [JsonInclude, JsonPropertyName("last_updated")]
        public DateTime LastUpdatedAt { get; internal set; }

        /// <summary> Indicates whether this Cheermote provides a charitable contribution match during charity campaigns. </summary>
        [JsonInclude, JsonPropertyName("is_charitable")]
        public bool IsCharitable { get; internal set; }
    }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Badge
    {
        /// <summary> An ID that identifies this set of chat badges. </summary>
        [JsonPropertyName("set_id")]
        public string SetId { get; set; }

        /// <summary> A collection of chat badges in this set. </summary>
        [JsonPropertyName("versions")]
        public IReadOnlyCollection<BadgeVersion> Versions { get; set; }
    }
}

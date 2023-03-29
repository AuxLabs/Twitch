using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Raid
    {
        /// <summary> The UTC date and time of when the raid was requested. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary> Indicates whether the channel being raided contains mature content. </summary>
        [JsonInclude, JsonPropertyName("is_mature")]
        public bool IsMature { get; internal set; }
    }
}

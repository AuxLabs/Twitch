using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Vacation
    {
        /// <summary> The UTC date and time of when the broadcaster’s vacation starts. </summary>
        [JsonInclude, JsonPropertyName("start_time")]
        public DateTime StartsAt { get; internal set; }

        /// <summary> The UTC date and time of when the broadcaster’s vacation ends. </summary>
        [JsonInclude, JsonPropertyName("end_time")]
        public DateTime EndsAt { get; internal set; }
    }
}

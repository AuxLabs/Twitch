using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Vacation
    {
        /// <summary> The UTC date and time of when the broadcaster’s vacation starts. </summary>
        [JsonPropertyName("start_time")]
        public DateTime StartsAt { get; set; }

        /// <summary> The UTC date and time of when the broadcaster’s vacation ends. </summary>
        [JsonPropertyName("end_time")]
        public DateTime EndsAt { get; set; }
    }
}

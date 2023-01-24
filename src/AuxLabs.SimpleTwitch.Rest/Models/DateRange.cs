using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public struct DateRange
    {
        [JsonConstructor]
        public DateRange(DateTime startedAt, DateTime endedAt)
            => (StartedAt, EndedAt) = (startedAt, endedAt);

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; }
    }
}

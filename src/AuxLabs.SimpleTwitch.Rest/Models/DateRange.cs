using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public readonly struct DateRange
    {
        [JsonConstructor]
        public DateRange(DateTime startedAt, DateTime endedAt)
            => (StartedAt, EndedAt) = (startedAt, endedAt);

        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; }

        [JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; }
    }
}

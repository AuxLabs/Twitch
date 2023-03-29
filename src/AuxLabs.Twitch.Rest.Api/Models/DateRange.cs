using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public readonly struct DateRange
    {
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; }

        [JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; }

        [JsonConstructor]
        public DateRange(DateTime startedAt, DateTime endedAt)
            => (StartedAt, EndedAt) = (startedAt, endedAt);
    }
}

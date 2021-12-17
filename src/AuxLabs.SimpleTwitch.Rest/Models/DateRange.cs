using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public struct DateRange
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

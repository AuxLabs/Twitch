using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Schedule
    {
        /// <summary> The list of broadcasts in the broadcaster’s streaming schedule. </summary>
        [JsonPropertyName("segments")]
        public IReadOnlyCollection<ScheduleSegment> Segments { get; set; }

        /// <summary> The ID of the broadcaster that owns the broadcast schedule. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> The dates when the broadcaster is on vacation and not streaming. </summary>
        [JsonPropertyName("vacation")]
        public Vacation Vacation { get; set; }
    }
}

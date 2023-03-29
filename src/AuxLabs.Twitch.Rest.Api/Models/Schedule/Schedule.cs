using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class Schedule
    {
        /// <summary> The list of broadcasts in the broadcaster’s streaming schedule. </summary>
        [JsonInclude, JsonPropertyName("segments")]
        public IReadOnlyCollection<ScheduleSegment> Segments { get; internal set; }

        /// <summary> The ID of the broadcaster that owns the broadcast schedule. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> The dates when the broadcaster is on vacation and not streaming. </summary>
        [JsonInclude, JsonPropertyName("vacation")]
        public Vacation Vacation { get; internal set; }
    }
}

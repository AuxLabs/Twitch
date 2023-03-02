using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class HypeTrainInfo
    {
        /// <summary> An ID that identifies this event. </summary>
        [JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The type of event. </summary>
        [JsonPropertyName("event_type")]
        public string Type { get; internal set; }

        /// <summary> The UTC date and time that the event occurred. </summary>
        [JsonPropertyName("event_timestamp")]
        public DateTime Timestamp { get; internal set; }

        /// <summary> The version number of the definition of the event’s data. </summary>
        [JsonPropertyName("version")]
        public string Version { get; internal set; }

        /// <summary> The event's data. </summary>
        [JsonPropertyName("event_data")]
        public HypeTrain Data { get; internal set; }
    }
}

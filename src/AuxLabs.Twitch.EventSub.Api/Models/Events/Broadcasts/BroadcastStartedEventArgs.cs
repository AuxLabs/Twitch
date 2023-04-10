using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class BroadcastStartedEventArgs : BroadcastEndedEventArgs
    {
        /// <summary> The id of the stream. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The stream type. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public BroadcastType Type { get; internal set; }

        /// <summary> The timestamp at which the stream went online at. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }
    }
}

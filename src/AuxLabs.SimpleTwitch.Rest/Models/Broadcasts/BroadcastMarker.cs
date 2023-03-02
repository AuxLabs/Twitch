using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class BroadcastMarker
    {
        /// <summary> An ID that identifies this marker. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The UTC date and time of when the user created the marker. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> The relative offset (in seconds) of the marker from the beginning of the stream. </summary>
        [JsonInclude, JsonPropertyName("position_seconds")]
        public int PositionSeconds { get; set; }

        /// <summary> A description that the user gave the marker to help them remember why they marked the location. </summary>
        [JsonInclude, JsonPropertyName("description")]
        public string Description { get; set; }
    }
}

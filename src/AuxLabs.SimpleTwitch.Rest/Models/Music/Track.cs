using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Track
    {
        /// <summary> Describes the album that the track is found on. </summary>
        [JsonInclude, JsonPropertyName("album")]
        public Album Album { get; internal set; }

        /// <summary> The artists included on the track. </summary>
        [JsonInclude, JsonPropertyName("artists")]
        public IReadOnlyCollection<Artist> Artists { get; internal set; }

        /// <summary> The duration of the track, in seconds. </summary>
        [JsonInclude, JsonPropertyName("duration")]
        public int DurationSeconds { get; internal set; }

        /// <summary> The track’s Amazon Standard Identification Number. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The track’s International Standard Recording Code. </summary>
        [JsonInclude, JsonPropertyName("isrc")]
        public string Isrc { get; internal set; }

        /// <summary> The track’s title. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }
    }
}

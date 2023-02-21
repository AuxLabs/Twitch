using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Track
    {
        /// <summary> Describes the album that the track is found on. </summary>
        [JsonPropertyName("album")]
        public Album Album { get; set; }

        /// <summary> The artists included on the track. </summary>
        [JsonPropertyName("artists")]
        public IReadOnlyCollection<Artist> Artists { get; set; }

        /// <summary> The duration of the track, in seconds. </summary>
        [JsonPropertyName("duration")]
        public int DurationSeconds { get; set; }

        /// <summary> The track’s Amazon Standard Identification Number. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The track’s International Standard Recording Code. </summary>
        [JsonPropertyName("isrc")]
        public string Isrc { get; set; }

        /// <summary> The track’s title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}

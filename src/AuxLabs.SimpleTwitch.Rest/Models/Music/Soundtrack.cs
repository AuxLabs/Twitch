using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Soundtrack
    {
        /// <summary> Describes a track. </summary>
        [JsonPropertyName("track")]
        public Track Track { get; internal set; }

        /// <summary> The source of the track that’s currently playing. </summary>
        [JsonPropertyName("source")]
        public TrackSource Source { get; internal set; }
    }
}

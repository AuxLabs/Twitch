using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TrackSource
    {
        /// <summary> The type of content that this source maps to. </summary>
        [JsonPropertyName("content_type")]
        public TrackSourceType Type { get; internal set; }

        /// <summary> The playlist’s or station’s Amazon Standard Identification Number. </summary>
        [JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> A URL to the playlist’s or station’s image art. </summary>
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; internal set; }

        /// <summary> A URL to the playlist on Soundtrack. </summary>
        [JsonPropertyName("soundtrack_url")]
        public string SoundtrackUrl { get; internal set; }

        /// <summary> A URL to the playlist on Spotify. </summary>
        [JsonPropertyName("spotify_url")]
        public string SpotifyUrl { get; internal set; }

        /// <summary> The playlist’s or station’s title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; internal set; }
    }
}

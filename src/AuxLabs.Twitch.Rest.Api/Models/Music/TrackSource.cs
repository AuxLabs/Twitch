using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class TrackSource
    {
        /// <summary> The type of content that this source maps to. </summary>
        [JsonInclude, JsonPropertyName("content_type")]
        public TrackSourceType Type { get; internal set; }

        /// <summary> The playlist’s or station’s Amazon Standard Identification Number. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> A URL to the playlist’s or station’s image art. </summary>
        [JsonInclude, JsonPropertyName("image_url")]
        public string ImageUrl { get; internal set; }

        /// <summary> A URL to the playlist on Soundtrack. </summary>
        [JsonInclude, JsonPropertyName("soundtrack_url")]
        public string SoundtrackUrl { get; internal set; }

        /// <summary> A URL to the playlist on Spotify. </summary>
        [JsonInclude, JsonPropertyName("spotify_url")]
        public string SpotifyUrl { get; internal set; }

        /// <summary> The playlist’s or station’s title. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }
    }
}

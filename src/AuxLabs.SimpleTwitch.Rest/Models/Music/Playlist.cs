using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Playlist
    {
        /// <summary> A short description about the music that the playlist includes. </summary>
        [JsonPropertyName("description")]
        public string Description { get; internal set; }

        /// <summary> The playlist’s Amazon Standard Identification Number. </summary>
        [JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> A URL to the playlist’s image art. </summary>
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; internal set; }

        /// <summary> The playlist’s title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; internal set; }
    }
}

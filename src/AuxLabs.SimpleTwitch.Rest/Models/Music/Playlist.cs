using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Playlist
    {
        /// <summary> A short description about the music that the playlist includes. </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary> The playlist’s Amazon Standard Identification Number. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> A URL to the playlist’s image art. </summary>
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        /// <summary> The playlist’s title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}

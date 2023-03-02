using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Playlist
    {
        /// <summary> A short description about the music that the playlist includes. </summary>
        [JsonInclude, JsonPropertyName("description")]
        public string Description { get; internal set; }

        /// <summary> The playlist’s Amazon Standard Identification Number. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> A URL to the playlist’s image art. </summary>
        [JsonInclude, JsonPropertyName("image_url")]
        public string ImageUrl { get; internal set; }

        /// <summary> The playlist’s title. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Album
    {
        /// <summary> The album’s Amazon Standard Identification Number. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> A URL to the album’s cover art. </summary>
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        /// <summary> The album’s name. </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

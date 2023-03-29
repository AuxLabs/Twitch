using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Album
    {
        /// <summary> The album’s Amazon Standard Identification Number. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> A URL to the album’s cover art. </summary>
        [JsonInclude, JsonPropertyName("image_url")]
        public string ImageUrl { get; internal set; }

        /// <summary> The album’s name. </summary>
        [JsonInclude, JsonPropertyName("name")]
        public string Name { get; internal set; }
    }
}

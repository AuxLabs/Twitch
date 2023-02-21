using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Category
    {
        /// <summary> An ID that identifies the category. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The category’s name. </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary> A URL to the category’s box art. </summary>
        [JsonPropertyName("box_art_url")]
        public string BoxArtUrl { get; set; }
    }
}

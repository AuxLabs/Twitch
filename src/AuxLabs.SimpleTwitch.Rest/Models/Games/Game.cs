using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Game
    {
        /// <summary> An ID that identifies the category or game. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The category’s or game’s name. </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary> A URL to the category’s or game’s box art. </summary>
        [JsonPropertyName("box_art_url")]
        public string BoxArtUrl { get; set; }

        /// <summary> The ID that <see href="https://www.igdb.com/">IGDB</see> uses to identify this game. </summary>
        [JsonPropertyName("igdb_id")]
        public string IgdbId { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class Game : Category
    {
        /// <summary> The ID that <see href="https://www.igdb.com/">IGDB</see> uses to identify this game. </summary>
        [JsonInclude, JsonPropertyName("igdb_id")]
        public string IgdbId { get; set; }
    }
}

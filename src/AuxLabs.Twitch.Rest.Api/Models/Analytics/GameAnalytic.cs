using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    /// <summary> Contains information about a game's analytic report. </summary>
    public class GameAnalytic : Analytic
    {
        /// <summary> An ID that identifies the game that the report was generated for. </summary>
        [JsonInclude, JsonPropertyName("game_id")]
        public string GameId { get; internal set; }
    }
}

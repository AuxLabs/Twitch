using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class GameAnalytic : Analytic
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; init; }

    }
}

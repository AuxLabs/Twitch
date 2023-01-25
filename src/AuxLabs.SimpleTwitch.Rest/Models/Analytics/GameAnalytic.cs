using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GameAnalytic : Analytic
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetGameAnalyticsParams : GetAnalyticsParams
    {
        public override string[] Scopes { get; } = { "analytics:read:games" };

        /// <summary>
        /// Game ID
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }
    }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetGameAnalyticsParams : GetAnalyticsParams, IScoped
    {
        public static string[] Scopes { get; } = { "analytics:read:games" };

        /// <summary> The game’s client ID. </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            if (GameId != null)
                map["game_id"] = GameId;
            return map;
        }
    }
}

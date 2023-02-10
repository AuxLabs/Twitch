using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetGameAnalyticsArgs : GetAnalyticsArgs, IScoped
    {
        public string[] Scopes { get; } = { "analytics:read:games" };

        /// <summary> Optional, the game's client ID. </summary>
        public string GameId { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Validate();
            Require.NotEmptyOrWhitespace(GameId, nameof(GameId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();

            if (GameId != null)
                map["game_id"] = GameId;
            
            return map;
        }
    }
}

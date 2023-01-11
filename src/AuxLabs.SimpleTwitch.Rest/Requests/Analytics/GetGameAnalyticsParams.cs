namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetGameAnalyticsParams : GetAnalyticsParams, IScoped
    {
        public string[] Scopes { get; } = { "analytics:read:games" };

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

using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetGamesArgs : QueryMap<string[]>
    {
        /// <summary> The IDs of the category or game to get. </summary>
        public List<string> GameIds { get; set; }

        /// <summary> The name of the categories or games to get. </summary>
        public List<string> GameNames { get; set; }

        /// <summary> The IGDB IDs of the games to get. </summary>
        public List<string> IgdbIds { get; set; }

        public void Validate()
        {
            int? total = GameIds?.Count + GameNames?.Count + IgdbIds?.Count;
            Require.AtMost(total, 100, nameof(total), $"The combined item total of [{nameof(GameIds)}, {nameof(GameNames)}, {nameof(IgdbIds)}] must be at most 100");
            Require.HasAtLeast(GameIds, 1, nameof(GameIds));
            Require.HasAtLeast(GameNames, 1, nameof(GameNames));
            Require.HasAtLeast(IgdbIds, 1, nameof(IgdbIds));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();

            if (GameIds?.Count > 0)
                map["id"] = GameIds.ToArray();
            if (GameNames?.Count > 0)
                map["name"] = GameNames.ToArray();
            if (IgdbIds?.Count > 0)
                map["igdb_id"] = IgdbIds.ToArray();

            return map;
        }
    }
}

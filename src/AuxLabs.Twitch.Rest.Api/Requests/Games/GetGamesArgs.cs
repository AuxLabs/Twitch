using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class GetGamesArgs : QueryMap
    {
        /// <summary> The IDs of the category or game to get. </summary>
        public string[] GameIds { get; set; }

        /// <summary> The name of the categories or games to get. </summary>
        public string[] GameNames { get; set; }

        /// <summary> The IGDB IDs of the games to get. </summary>
        public string[] IgdbIds { get; set; }

        public void Validate()
        {
            int? total = GameIds?.Length + GameNames?.Length + IgdbIds?.Length;
            Require.AtMost(total, 100, nameof(total), $"The combined item total of [{nameof(GameIds)}, {nameof(GameNames)}, {nameof(IgdbIds)}] must be at most 100");
            Require.HasAtLeast(GameIds, 1, nameof(GameIds));
            Require.HasAtLeast(GameNames, 1, nameof(GameNames));
            Require.HasAtLeast(IgdbIds, 1, nameof(IgdbIds));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            if (GameIds?.Length > 0)
            {
                foreach (var item in GameIds)
                    map["id"] = item;
            }
            if (GameNames?.Length > 0)
            {
                foreach (var item in GameNames)
                    map["name"] = item;
            }
            if (IgdbIds?.Length > 0)
            {
                foreach (var item in IgdbIds)
                    map["igdb_id"] = item;
            }

            return map;
        }
    }
}

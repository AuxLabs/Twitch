﻿using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetGamesArgs : QueryMap<string[]>
    {
        /// <summary> The IDs of the category or game to get. </summary>
        public List<string> GameIds { get; set; } = new List<string>();

        /// <summary> The name of the categories or games to get. </summary>
        public List<string> GameNames { get; set; } = new List<string>();

        /// <summary> The IGDB IDs of the games to get. </summary>
        public List<string> IgdbIds { get; set; } = new List<string>();

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();

            if (GameIds.Count > 0)
                map["id"] = GameIds.ToArray();
            if (GameNames.Count > 0)
                map["name"] = GameNames.ToArray();
            if (IgdbIds.Count > 0)
                map["igdb_id"] = IgdbIds.ToArray();

            return map;
        }
    }
}

using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetTopGamesArgs : QueryMap, IPaginated
    {
        public int? First { get; set; }
        public string Before { get; set; }
        public string After { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (First != null)
                map["first"] = First.Value.ToString();
            if (Before != null)
                map["before"] = Before;
            if (After != null)
                map["after"] = After;

            return map;
        }
    }
}

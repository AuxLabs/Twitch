using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetFollowsParams : QueryMap
    {
        public string FromId { get; set; }

        public string ToId { get; set; }

        public int First { get; set; }

        public string After { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            if (After != null)
                map["from_id"] = FromId;
            if (After != null)
                map["to_id"] = ToId;
            if (After != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;
            return map;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetPollsArgs : QueryMap<string[]>, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "channel:read:polls", "channel:manage:polls" };

        /// <summary> The ID of the broadcaster that created the polls. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> A list of IDs that identify the polls to return. </summary>
        public List<string> PollIds { get; set; } = new List<string>();

        public int? First { get; set; }
        public string After { get; set; }

        public GetPollsArgs() { }
        public GetPollsArgs(string broadcasterid, params string[] pollIds)
        {
            PollIds = pollIds.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>
            {
                ["broadcaster_id"] = new[] { BroadcasterId }
            };

            if (PollIds.Count > 0)
                map["id"] = PollIds.ToArray();
            if (First != null)
                map["first"] = new[] { First.Value.ToString() };
            if (After != null)
                map["after"] = new[] { After };

            return map;
        }

        string IPaginated.Before { get; set; }
    }
}

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
        public List<string> PollIds { get; set; }

        public int? First { get; set; }
        public string After { get; set; }

        public GetPollsArgs() { }
        public GetPollsArgs(string broadcasterId, params string[] pollIds)
        {
            BroadcasterId = broadcasterId;
            PollIds = pollIds.ToList();
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.HasAtLeast(PollIds, 1, nameof(PollIds));
            Require.HasAtMost(PollIds, 20, nameof(PollIds));
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 20, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();
            
            if (BroadcasterId != null)
                map["broadcaster_id"] = new[] { BroadcasterId };
            if (PollIds?.Count > 0)
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

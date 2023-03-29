using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetPollsArgs : QueryMap, IPaginatedRequest, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:read:polls", "channel:manage:polls" };

        /// <summary> The ID of the broadcaster that created the polls. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> A list of IDs that identify the polls to return. </summary>
        public string[] PollIds { get; set; }

        public int? First { get; set; }
        public string After { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
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

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);
            
            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (PollIds?.Length > 0)
            {
                foreach (var item in PollIds)
                    map["id"] = item;
            }
            if (First != null)
                map["first"] = First.Value.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginatedRequest.Before { get; set; }
    }
}

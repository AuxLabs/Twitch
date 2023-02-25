using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ManageSegmentArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:schedule" };

        /// <summary> The ID of the broadcaster who owns the broadcast segment to update. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the broadcast segment to update. </summary>
        public string SegmentId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(SegmentId, nameof(SegmentId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId,
                ["id"] = SegmentId
            };
        }
    }
}

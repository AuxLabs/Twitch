using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostSegmentArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:schedule" };

        /// <summary> The ID of the broadcaster that owns the schedule to add the broadcast segment to. </summary>
        public string BroadcasterId { get; set; }

        public PostSegmentArgs() { }
        public PostSegmentArgs(string broadcasterId)
            => BroadcasterId = broadcasterId;

        public override string ToString()
            => BroadcasterId;

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };
        }
        public static implicit operator string(PostSegmentArgs value) => value.ToString();
        public static implicit operator PostSegmentArgs(string v) => new PostSegmentArgs(v);
    }
}

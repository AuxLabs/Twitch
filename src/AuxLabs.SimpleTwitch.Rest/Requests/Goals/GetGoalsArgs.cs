using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetGoalsArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:read:goals" };

        /// <summary> The ID of the broadcaster that created the goals. </summary>
        public string BroadcasterId { get; set; }

        public GetGoalsArgs() { }
        public GetGoalsArgs(string broadcasterId)
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

        public static implicit operator string(GetGoalsArgs value) => value.ToString();
        public static implicit operator GetGoalsArgs(string v) => new GetGoalsArgs(v);
    }
}

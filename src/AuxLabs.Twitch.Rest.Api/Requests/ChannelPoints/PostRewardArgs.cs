using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PostRewardArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:redemptions" };

        /// <summary> The ID of the broadcaster to add the custom reward to. </summary>
        public string BroadcasterId { get; set; }

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
    }
}

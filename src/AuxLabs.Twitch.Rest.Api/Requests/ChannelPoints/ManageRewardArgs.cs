using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class ManageRewardArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:redemptions" };

        /// <summary> The ID of the broadcaster that created the custom reward. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the custom reward to delete. </summary>
        public string RewardId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(RewardId, nameof(RewardId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId,
                ["id"] = RewardId
            };
        }
    }
}

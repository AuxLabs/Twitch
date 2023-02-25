using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ManageRewardArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "channel:manage:redemptions" };

        /// <summary>  </summary>
        public string BroadcasterId { get; set; }

        /// <summary>  </summary>
        public string RewardId { get; set; }

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

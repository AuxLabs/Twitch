using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetRewardArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:read:redemptions" };

        /// <summary> The ID of the broadcaster whose custom rewards you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> Determines whether the response contains only the custom rewards that the app can manage. </summary>
        public bool? OnlyManagebleRewards { get; set; }

        /// <summary> A list of IDs to filter the rewards by. </summary>
        /// <remarks> You may specify a maximum of 50 IDs. </remarks>
        public List<string> CustomRewardIds { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.HasAtMost(CustomRewardIds, 50, nameof(CustomRewardIds));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);
            
            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (CustomRewardIds?.Count > 0)
            {
                foreach (var item in CustomRewardIds)
                    map["id"] = item;
            }
            if (OnlyManagebleRewards != null)
                map["only_manageable_rewards"] = OnlyManagebleRewards.Value.ToString();

            return map;
        }
    }
}

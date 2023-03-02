﻿using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ModifyRedemptionsArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:redemptions" };

        /// <summary> The ID of the broadcaster that owns the custom reward. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID that identifies the custom reward whose redemptions you want to get. </summary>
        public string RewardId { get; set; }

        /// <summary> A list of IDs to filter the redemptions by. </summary>
        /// <remarks> You may specify a maximum of 50 IDs. </remarks>
        public string[] Ids { get; set; }

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
            Require.NotNull(Ids, nameof(Ids));
            Require.HasAtLeast(Ids, 1, nameof(Ids));
            Require.HasAtMost(Ids, 50, nameof(Ids));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (RewardId != null)
                map["reward_id"] = RewardId;
            if (Ids?.Length > 0)
            {
                foreach (var item in Ids)
                    map["id"] = item;
            }

            return map;
        }
    }
}

using System;
using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetRedemptionsArgs : QueryMap<string[]>, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "channel:read:redemptions" };

        /// <summary> The ID of the broadcaster that owns the custom reward. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID that identifies the custom reward whose redemptions you want to get. </summary>
        public string RewardId { get; set; }

        /// <summary> The status of the redemptions to return. </summary>
        public RedemptionStatus? Status { get; set; }

        /// <summary> A list of IDs to filter the redemptions by. </summary>
        /// <remarks> You may specify a maximum of 50 IDs. </remarks>
        public List<string> Ids { get; set; }

        /// <summary> The order to sort redemptions by. </summary>
        public RedemptionSort? Sort { get; set; }

        /// <inheritdoc/>
        /// <remarks> The minimum is 1 per page and the maximum is 50. Defaults to 20. </remarks>
        public int? First { get; set; }

        /// <inheritdoc/>
        public string After { get; set; }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            if (RewardId != null && Ids != null)
                throw new ArgumentException($"{nameof(RewardId)} and {nameof(Ids)} cannot be specified on the same request.");
            if (RewardId == null && Ids == null)
                throw new ArgumentException($"Either {nameof(RewardId)} or {nameof(Ids)} must be specified.");

            var map = new Dictionary<string, string[]>
            {
                ["status"] = new[] { Status.Value.GetEnumMemberValue() }
            };

            if (BroadcasterId != null)
                map["broadcaster_id"] = new[] { BroadcasterId };
            if (RewardId != null)
                map["reward_id"] = new[] { RewardId };
            if (Ids != null)
                map["id"] = Ids.ToArray();
            if (Sort != null)
                map["sort"] = new[] { Sort.Value.GetEnumMemberValue() };
            if (After != null)
                map["after"] = new[] { After };
            if (First != null)
                map["first"] = new[] { First.Value.ToString() };
            return map;
        }
    }
}

using System;
using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ModifyRedemptionsArgs : QueryMap<string[]>
    {
        /// <summary> The ID of the broadcaster that owns the custom reward. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID that identifies the custom reward whose redemptions you want to get. </summary>
        public string RewardId { get; set; }

        /// <summary> A list of IDs to filter the redemptions by. </summary>
        /// <remarks> You may specify a maximum of 50 IDs. </remarks>
        public List<string> Ids { get; set; }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            if (RewardId != null && Ids != null)
                throw new ArgumentException($"{nameof(RewardId)} and {nameof(Ids)} cannot be specified on the same request.");
            if (RewardId == null && Ids == null)
                throw new ArgumentException($"Either {nameof(RewardId)} or {nameof(Ids)} must be specified.");

            var map = new Dictionary<string, string[]>();
            if (BroadcasterId != null)
                map["broadcaster_id"] = new[] { BroadcasterId };
            if (RewardId != null)
                map["reward_id"] = new[] { RewardId };
            if (Ids != null)
                map["id"] = Ids.ToArray();
            return map;
        }
    }
}

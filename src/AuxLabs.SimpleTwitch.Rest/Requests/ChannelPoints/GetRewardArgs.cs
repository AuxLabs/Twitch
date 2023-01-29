using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetRewardArgs : QueryMap<string[]>
    {
        /// <summary> The ID of the broadcaster whose custom rewards you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> Determines whether the response contains only the custom rewards that the app can manage. </summary>
        public bool? OnlyManagebleRewards { get; set; }

        /// <summary> A list of IDs to filter the rewards by. </summary>
        public IEnumerable<string> CustomRewardIds { get; set; }

        public GetRewardArgs() { }
        public GetRewardArgs(string broadcasterId, params string[] customRewardIds)
            : this(broadcasterId, null, customRewardIds) { }
        public GetRewardArgs(string broadcasterId, bool? onlyManageble, params string[] customRewardIds)
        {
            BroadcasterId = broadcasterId;
            OnlyManagebleRewards = onlyManageble;
            CustomRewardIds = customRewardIds.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();
            var list = new List<string>();
            foreach (var id in CustomRewardIds)
                list.Add(id);
            map["id"] = list.ToArray();
            map["broadcaster_id"] = new[] { BroadcasterId };
            if (OnlyManagebleRewards != null)
                map["only_manageable_rewards"] = new[] { OnlyManagebleRewards.Value ? "1" : "0" };
            return map;
        }
    }
}

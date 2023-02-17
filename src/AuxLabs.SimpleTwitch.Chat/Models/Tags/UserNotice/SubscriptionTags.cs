using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class SubscriptionTags : UserNoticeTags
    {
        /// <summary> The total number of months the user has subscribed. </summary>
        public int TotalMonths { get; set; }

        /// <summary> The number of consecutive months the user has subscribed. </summary>
        public int StreakMonths { get; set; }

        /// <summary> Indicates whether the user wants their streaks shared. </summary>
        public bool IsStreakShared { get; set; }

        /// <summary> The display name of the subscription plan. This may be a default name or one created by the channel owner </summary>
        public string SubscriptionName { get; set; }

        /// <summary> The type of subscription plan being used. </summary>
        public SubscriptionType SubscriptionType { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-param-cumulative-months"] = TotalMonths.ToString();
            map["msg-param-should-share-streak"] = IsStreakShared ? "1" : "0";
            map["msg-param-streak-months"] = StreakMonths.ToString();
            map["msg-param-sub-plan"] = SubscriptionType.GetStringValue();
            map["msg-param-sub-plan-name"] = SubscriptionName;
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-param-cumulative-months", out string str))
                TotalMonths = int.Parse(str);
            if (map.TryGetValue("msg-param-should-share-streak", out str))
                IsStreakShared = str == "1";
            if (map.TryGetValue("msg-param-streak-months", out str))
                StreakMonths = int.Parse(str);
            if (map.TryGetValue("msg-param-sub-plan", out str))
                SubscriptionType = EnumHelper.GetEnumValue<SubscriptionType>(str);
            if (map.TryGetValue("msg-param-sub-plan-name", out str))
                SubscriptionName = str;
        }
    }
}

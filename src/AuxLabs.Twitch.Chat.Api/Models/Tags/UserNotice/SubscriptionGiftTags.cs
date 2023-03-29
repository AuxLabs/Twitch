﻿using System.Collections.Generic;

namespace AuxLabs.Twitch.Chat.Models
{
    public class SubscriptionGiftTags : UserNoticeTags
    {
        /// <summary> The user ID of the subscription gift recipient. </summary>
        public string RecipientId { get; internal set; }

        /// <summary> The display name of the subscription gift recipient. </summary>
        public string RecipientDisplayName { get; internal set; }

        /// <summary> The user name of the subscription gift recipient. </summary>
        public string RecipientName { get; internal set; }

        /// <summary> The display name of the subscription plan. This may be a default name or one created by the channel owner. </summary>
        public string SubscriptionName { get; internal set; }

        /// <summary> The type of subscription plan being used. </summary>
        public SubscriptionType SubscriptionType { get; internal set; }

        /// <summary> The number of months gifted as part of a single, multi-month gift. </summary>
        public int GiftedMonths { get; internal set; }

        /// <summary> The total number of months the user has subscribed. </summary>
        public int TotalMonths { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-param-recipient-id"] = RecipientId;
            map["msg-param-recipient-display-name"] = RecipientDisplayName;
            map["msg-param-recipient-user-name"] = RecipientName;
            map["msg-param-sub-plan-name"] = SubscriptionName;
            map["msg-param-sub-plan"] = SubscriptionType.GetStringValue();
            map["msg-param-gift-months"] = GiftedMonths.ToString();
            map["msg-param-months"] = TotalMonths.ToString();
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-param-displayName", out string str))
                RecipientId = str;
            if (map.TryGetValue("msg-param-displayName", out str))
                RecipientDisplayName = str;
            if (map.TryGetValue("msg-param-displayName", out str))
                RecipientName = str;
            if (map.TryGetValue("msg-param-displayName", out str))
                SubscriptionName = str;
            if (map.TryGetValue("msg-param-displayName", out str))
                SubscriptionType = EnumHelper.GetEnumValue<SubscriptionType>(str);
            if (map.TryGetValue("msg-param-displayName", out str))
                GiftedMonths = int.Parse(str);
            if (map.TryGetValue("msg-param-displayName", out str))
                TotalMonths = int.Parse(str);
        }
    }
}
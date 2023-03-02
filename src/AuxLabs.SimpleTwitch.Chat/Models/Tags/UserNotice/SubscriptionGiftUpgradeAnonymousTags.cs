using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class SubscriptionGiftUpgradeAnonymousTags : UserNoticeTags
    {
        /// <summary> The number of gifts the gifter has given. </summary>
        public int PromoGiftTotal { get; internal set; }

        /// <summary> The subscriptions promo, if any, that is ongoing. </summary>
        public string PromoGiftName { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-param-promo-gift-total"] = PromoGiftTotal.ToString();
            map["msg-param-promo-name"] = PromoGiftName;
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-param-promo-gift-total", out string str))
                PromoGiftTotal = int.Parse(str);
            if (map.TryGetValue("msg-param-promo-name", out str))
                PromoGiftName = str;
        }
    }
}

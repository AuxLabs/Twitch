using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class SubscriptionGiftUpgradeTags : SubscriptionGiftUpgradeAnonymousTags
    {
        /// <summary> The login name of the user who gifted the subscription. </summary>
        public string SenderLogin { get; internal set; }

        /// <summary> The display name of the user who gifted the subscription. </summary>
        public string SenderDisplayName { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["key"] = "value";
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
        }
    }
}

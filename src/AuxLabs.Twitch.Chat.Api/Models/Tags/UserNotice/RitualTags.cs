using System.Collections.Generic;

namespace AuxLabs.Twitch.Chat.Models
{
    public class RitualTags : UserNoticeTags
    {
        /// <summary> The name of the ritual being celebrated. </summary>
        public RitualType RitualType { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-param-ritual-name"] = RitualType.GetStringValue();
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-param-ritual-name", out string str))
                RitualType = EnumHelper.GetEnumValue<RitualType>(str);
        }
    }
}

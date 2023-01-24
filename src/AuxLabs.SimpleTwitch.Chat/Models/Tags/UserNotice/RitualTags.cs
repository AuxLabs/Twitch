namespace AuxLabs.SimpleTwitch.Chat
{
    public class RitualTags : UserNoticeTags
    {
        /// <summary>
        /// The name of the ritual being celebrated.
        /// </summary>
        public RitualType RitualType { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-param-ritual-name"] = RitualType.GetEnumMemberValue();
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-param-ritual-name", out string str))
                RitualType = EnumHelper.GetValueFromEnumMember<RitualType>(str);
        }
    }
}

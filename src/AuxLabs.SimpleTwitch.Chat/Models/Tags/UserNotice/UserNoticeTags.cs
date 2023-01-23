namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class UserNoticeTags : MessageTags
    {
        public UserNoticeType NoticeType { get; set; }
        public string SystemMessage { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-id"] = NoticeType.GetEnumMemberValue();
            map["system-msg"] = SystemMessage;
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-id", out string str))
                NoticeType = EnumHelper.GetValueFromEnumMember<UserNoticeType>(str);
            if (map.TryGetValue("system-id", out str))
                SystemMessage = str;
        }
    }
}

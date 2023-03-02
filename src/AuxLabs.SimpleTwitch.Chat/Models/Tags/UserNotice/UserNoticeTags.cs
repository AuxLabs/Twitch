using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class UserNoticeTags : MessageTags
    {
        /// <summary> The type of notice. </summary>
        public UserNoticeType NoticeType { get; internal set; }

        /// <summary> The message Twitch shows in the chat room for this notice. </summary>
        public string SystemMessage { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-id"] = NoticeType.GetStringValue();
            map["system-msg"] = SystemMessage;
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-id", out string str))
                NoticeType = EnumHelper.GetEnumValue<UserNoticeType>(str);
            if (map.TryGetValue("system-id", out str))
                SystemMessage = str;
        }
    }
}

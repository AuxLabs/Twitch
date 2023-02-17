using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class NoticeTags : BaseTags
    {
        /// <summary> A value to determine the action’s outcome. </summary>
        public NoticeType NoticeType { get; set; }

        /// <summary> The ID of the user that the action targeted. If specified. </summary>
        public string TargetUserId { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["msg-id"] = NoticeType.GetStringValue(),
                ["target-user-id"] = TargetUserId
            };
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("msg-id", out string str))
                NoticeType = EnumHelper.GetEnumValue<NoticeType>(str);
            if (map.TryGetValue("target-user-id", out str))
                TargetUserId = str;
        }
    }
}

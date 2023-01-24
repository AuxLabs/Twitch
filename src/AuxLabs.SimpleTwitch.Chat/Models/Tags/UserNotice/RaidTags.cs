namespace AuxLabs.SimpleTwitch.Chat
{
    public class RaidTags : UserNoticeTags
    {
        /// <summary>
        /// The display name of the broadcaster raiding this channel.
        /// </summary>
        public string RaiderDisplayName { get; set; }

        /// <summary>
        /// The login name of the broadcaster raiding this channel.
        /// </summary>
        public string RaiderLogin { get; set; }

        /// <summary>
        /// The number of viewers raiding this channel from the broadcaster’s channel.
        /// </summary>
        public int RaiderViewerCount { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["msg-param-displayName"] = RaiderDisplayName;
            map["msg-param-login"] = RaiderLogin;
            map["msg-param-viewerCount"] = RaiderViewerCount.ToString();
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("msg-param-displayName", out string str))
                RaiderDisplayName = str;
            if (map.TryGetValue("msg-param-login", out str))
                ReplyParentUserLogin = str;
            if (map.TryGetValue("msg-param-viewerCount", out str))
                RaiderViewerCount = int.Parse(str);
        }
    }
}

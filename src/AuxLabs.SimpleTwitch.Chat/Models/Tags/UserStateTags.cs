using System.Collections.Generic;
using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class UserStateTags : GlobalUserStateTags
    {
        public string MessageId { get; set; }
        public bool IsModerator { get; set; }
        public bool IsSubscriber { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["id"] = MessageId;
            map["mod"] = IsModerator ? "1" : "0";
            map["subscriber"] = IsSubscriber ? "1" : "0";
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            base.LoadQueryMap(map);
            if (map.TryGetValue("id", out string str))
                MessageId = str;
            if (map.TryGetValue("mod", out str))
                IsModerator = str == "1";
            if (map.TryGetValue("subscriber", out str))
                IsSubscriber = str == "1";
        }
    }
}

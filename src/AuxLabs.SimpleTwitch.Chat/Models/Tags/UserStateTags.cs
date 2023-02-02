using System.Collections.Generic;
using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class UserStateTags : GlobalUserStateTags
    {
        /// <summary> An ID that uniquely identifies a message, if one was sent. </summary>
        public string MessageId { get; set; }

        /// <summary> Indicates whether the user is a moderator </summary>
        public bool IsModerator { get; set; }

        /// <summary> Indicates whether the user is a subscriber. </summary>
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

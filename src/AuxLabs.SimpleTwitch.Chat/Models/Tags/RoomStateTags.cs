using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class RoomStateTags : BaseTags
    {
        /// <summary> An ID that identifies the channel. </summary>
        public string ChannelId { get; set; }

        /// <summary> Indicates whether the chat room allows only messages with emotes. </summary>
        public bool IsEmoteOnly { get; set; }

        /// <summary> Indicates whether only followers can post messages in the chat room. </summary>
        public bool IsFollowersOnly => FollowersOnlyMinutes > -1;

        /// <summary> Indicates how long, in minutes, the user must have followed the broadcaster before posting chat messages. </summary>
        public int FollowersOnlyMinutes { get; set; }

        /// <summary> Indicates whether a user’s messages must be unique. </summary>
        public bool IsUnique { get; set; }

        /// <summary>  </summary>
        public bool IsRituals { get; set; }

        /// <summary> Indicates whether users must wait between sending messages. </summary>
        public bool IsSlow  => SlowSeconds > 0;

        /// <summary> Indicates how long, in seconds, users must wait between sending messages. </summary>
        public int SlowSeconds { get; set; }

        /// <summary> Indicates whether only subscribers and moderators can chat in the chat room. </summary>
        public bool IsSubsOnly { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["room-id"] = ChannelId,
                ["emote-only"] = IsEmoteOnly ? "1" : "0",
                ["followers-only"] = FollowersOnlyMinutes.ToString(),
                ["r9k"] = IsUnique ? "1" : "0",
                ["rituals"] = IsRituals ? "1" : "0",
                ["slow"] = IsSlow ? "1" : "0",
                ["subs-only"] = IsSubsOnly ? "1" : "0"
            };
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("room-id", out string str))
                ChannelId = str;
            if (map.TryGetValue("emote-only", out str))
                IsEmoteOnly = str == "1";
            if (map.TryGetValue("followers-only", out str))
                FollowersOnlyMinutes = int.Parse(str);
            if (map.TryGetValue("r9k", out str))
                IsUnique = str == "1";
            if (map.TryGetValue("rituals", out str))
                IsRituals = str == "1";
            if (map.TryGetValue("slow", out str))
                SlowSeconds = int.Parse(str);
            if (map.TryGetValue("subs-only", out str))
                IsSubsOnly = str == "1";
        }
    }
}

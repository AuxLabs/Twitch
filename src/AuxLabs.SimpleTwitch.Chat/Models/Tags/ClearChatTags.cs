using System;
using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class ClearChatTags : BaseTags
    {
        /// <summary> The date and time this event occurred. </summary>
        public DateTime Timestamp { get; set; }

        /// <summary> The ID of the channel where the messages were removed from. </summary>
        public string ChannelId { get; set; }

        /// <summary> The ID of the user that was banned or put in a timeout. </summary>
        public string TargetUserId { get; set; }

        /// <summary> The message includes this tag if the user was put in a timeout. </summary>
        public TimeSpan? BanDuration { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["tim-sent-ts"] = Timestamp.ToString(),
                ["room-id"] = ChannelId,
                ["target-user-id"] = TargetUserId,
                ["ban-duration"] = BanDuration.ToString()
            };
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("tim-sent-ts", out string str))
                Timestamp = DateTime.Parse(str);
            if (map.TryGetValue("room-id", out str))
                ChannelId = str;
            if (map.TryGetValue("target-user-id", out str))
                TargetUserId = str;
            if (map.TryGetValue("ban-duration", out str))
                BanDuration = TimeSpan.FromSeconds(int.Parse(str));
        }
    }
}

using System;
using System.Collections.Generic;

namespace AuxLabs.Twitch.Chat
{
    public class ClearMessageTags : BaseTags
    {
        /// <summary> The date and time this event occurred. </summary>
        public DateTime Timestamp { get; internal set; }

        /// <summary> A UUID that identifies the message that was removed. </summary>
        public string TargetMessageId { get; internal set; }

        /// <summary> The name of the user who sent the message. </summary>
        public string UserName { get; internal set; }

        /// <summary> The ID of the channel (chat room) where the message was removed from. </summary>
        public string ChannelId { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["tim-sent-ts"] = Timestamp.ToString(),
                ["target-msg-id"] = TargetMessageId,
                ["login"] = UserName,
                ["room-id"] = ChannelId
            };
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("tim-sent-ts", out string str))
                Timestamp = DateTime.Parse(str);
            if (map.TryGetValue("target-msg-id", out str))
                TargetMessageId = str;
            if (map.TryGetValue("login", out str))
                UserName = str;
            if (map.TryGetValue("room-id", out str))
                ChannelId = str;
        }
    }
}

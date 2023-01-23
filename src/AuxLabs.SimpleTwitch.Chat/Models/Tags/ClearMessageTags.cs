﻿namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class ClearMessageTags : BaseTags
    {
        /// <summary>
        /// The date and time this event occurred.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// A UUID that identifies the message that was removed.
        /// </summary>
        public string TargetMessageId { get; set; }

        /// <summary>
        /// The name of the user who sent the message.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// The ID of the channel (chat room) where the message was removed from.
        /// </summary>
        public string ChannelId { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["tim-sent-ts"] = Timestamp.ToString(),
                ["target-msg-id"] = TargetMessageId,
                ["login"] = Login,
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
                Login = str;
            if (map.TryGetValue("room-id", out str))
                ChannelId = str;
        }
    }
}

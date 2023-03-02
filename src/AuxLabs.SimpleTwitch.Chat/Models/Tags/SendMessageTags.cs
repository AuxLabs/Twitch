using System;
using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class SendMessageTags : BaseTags
    {
        /// <summary> The id of the message to reply to </summary>
        public string ReplyMessageId { get; internal set; }

        public SendMessageTags(string replyMessageId) 
            => ReplyMessageId = replyMessageId;

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["reply-parent-msg-id"] = ReplyMessageId
            };
        }

        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
            => throw new NotSupportedException();
    }
}

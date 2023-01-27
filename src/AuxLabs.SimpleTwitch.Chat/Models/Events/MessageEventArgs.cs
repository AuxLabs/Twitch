using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class MessageEventArgs
    {
        public MessageTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }

        public MessageEventArgs(IrcPrefix? prefix, IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.LastOrDefault()[1..];
            UserName = prefix?.Username;
        }

        public static MessageEventArgs Create(IrcPayload payload)
        {
            var args = new MessageEventArgs(payload.Prefix, payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (MessageTags)payload.Tags;
            return args;
        }
    }
}

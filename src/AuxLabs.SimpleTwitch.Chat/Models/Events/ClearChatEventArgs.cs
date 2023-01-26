using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class ClearChatEventArgs
    {
        public ClearChatTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string UserName { get; set; }

        public ClearChatEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            UserName = parameters.ElementAtOrDefault(1)?.Trim(':');
        }

        public static ClearChatEventArgs Create(IrcPayload payload)
        {
            var args = new ClearChatEventArgs(payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (ClearChatTags)payload.Tags;
            return args;
        }
    }
}

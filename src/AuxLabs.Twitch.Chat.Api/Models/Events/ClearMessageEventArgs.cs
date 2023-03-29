using AuxLabs.Twitch.Chat.Api;
using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch.Chat.Models
{
    public class ClearMessageEventArgs
    {
        public ClearMessageTags Tags { get; internal set; }
        public string ChannelName { get; internal set; }
        public string Message { get; internal set; }

        public ClearMessageEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.ElementAt(1).Trim(':');
        }

        public static ClearMessageEventArgs Create(IrcPayload payload)
        {
            var args = new ClearMessageEventArgs(payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (ClearMessageTags)payload.Tags;
            return args;
        }
    }
}

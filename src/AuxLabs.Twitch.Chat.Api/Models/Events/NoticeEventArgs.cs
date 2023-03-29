using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch.Chat
{
    public class NoticeEventArgs
    {
        public NoticeTags Tags { get; internal set; }
        public string ChannelName { get; internal set; }
        public string Message { get; internal set; }

        public NoticeEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.LastOrDefault().Trim(':');
        }

        public static NoticeEventArgs Create(IrcPayload payload)
        {
            var args = new NoticeEventArgs(payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (NoticeTags)payload.Tags;
            return args;
        }
    }
}

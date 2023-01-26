using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class NoticeEventArgs
    {
        public NoticeTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string Message { get; set; }

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

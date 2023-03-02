using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class UserNoticeEventArgs
    {
        public UserNoticeTags Tags { get; internal set; }
        public string ChannelName { get; internal set; }
        public string Message { get; internal set; }

        public UserNoticeEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.ElementAtOrDefault(1)?.Trim(':');
        }

        public static UserNoticeEventArgs Create(IrcPayload payload)
        {
            var args = new UserNoticeEventArgs(payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (UserNoticeTags)payload.Tags;
            return args;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class UserNoticeEventArgs
    {
        public UserNoticeTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string Message { get; set; }

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

using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch.Chat
{
    public class UserStateEventArgs
    {
        public UserStateTags Tags { get; internal set; }
        public string ChannelName { get; internal set; }

        public UserStateEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.First().Trim('#');
        }

        public static UserStateEventArgs Create(IrcPayload payload)
        {
            var args = new UserStateEventArgs(payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (UserStateTags)payload.Tags;
            return args;
        }
    }
}

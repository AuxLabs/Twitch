using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class UserStateEventArgs
    {
        public UserStateTags Tags { get; set; }
        public string ChannelName { get; set; }

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

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class UserStateEventArgs : IChatUser
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

        Color? IChatUser.Color { get => Tags.Color; }
        string IUser.Name { get => null; }
        string IUser.DisplayName { get => Tags.DisplayName; }
        string IEntity<string>.Id { get => Tags.UserId; }
    }
}

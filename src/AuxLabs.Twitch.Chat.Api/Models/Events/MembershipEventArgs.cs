using AuxLabs.Twitch.Chat.Api;
using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch.Chat.Models
{
    public class MembershipEventArgs
    {
        public string ChannelName { get; internal set; }
        public string UserName { get; internal set; }

        public MembershipEventArgs(IrcPrefix prefix, IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            UserName = prefix.Username;
        }

        public static MembershipEventArgs Create(IrcPayload payload)
        {
            var args = new MembershipEventArgs(payload.Prefix.Value, payload.Parameters);
            return args;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class RoomStateEventArgs
    {
        public RoomStateTags Tags { get; set; }
        public string ChannelName { get; set; }

        public RoomStateEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
        }

        public static RoomStateEventArgs Create(IrcPayload payload)
        {
            var args = new RoomStateEventArgs(payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (RoomStateTags)payload.Tags;
            return args;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class ClearMessageEventArgs
    {
        public ClearMessageTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string Message { get; set; }

        public ClearMessageEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.ElementAt(1).Trim(':');
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class NamesEventArgs
    {
        public string ChannelName { get; set; }
        public IReadOnlyCollection<string> Names { get; set; }

        public NamesEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(2).Trim('#');
            Names = parameters.Last().Trim(':').Split(' ');
        }
    }
}

using AuxLabs.Twitch.Chat.Api;
using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch.Chat.Models
{
    public class NamesEventArgs
    {
        public string ChannelName { get; internal set; }
        public IReadOnlyCollection<string> Names { get; internal set; }

        public NamesEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(2).Trim('#');
            Names = parameters.Last().Trim(':').Split(' ');
        }
    }
}

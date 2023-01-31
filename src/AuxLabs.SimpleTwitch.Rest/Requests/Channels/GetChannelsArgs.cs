using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetChannelsArgs : QueryMap<string[]>
    { 
        public IEnumerable<string> ChannelIds { get; set; }

        public GetChannelsArgs() { }
        public GetChannelsArgs(params string[] channels)
        {
            ChannelIds = channels.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            return new Dictionary<string, string[]>
            {
                ["broadcaster_id"] = ChannelIds.ToArray()
            };
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetChannelsParams : QueryMap<string[]>
    { 
        public IEnumerable<string> ChannelIds { get; set; }

        public GetChannelsParams() { }
        public GetChannelsParams(params string[] channels)
        {
            ChannelIds = channels.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();
            var list = new List<string>();
            foreach (var id in ChannelIds)
                list.Add(id);
            map["broadcaster_id"] = list.ToArray();
            return map;
        }
    }
}
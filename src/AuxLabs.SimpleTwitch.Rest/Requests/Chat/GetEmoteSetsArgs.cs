using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetEmoteSetsArgs : QueryMap<string[]>
    {
        public List<string> EmoteSetIds { get; set; } = new List<string>();

        public GetEmoteSetsArgs() { }
        public GetEmoteSetsArgs(params string[] emoteSets)
        {
            EmoteSetIds = emoteSets.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            return new Dictionary<string, string[]>
            {
                ["emote_set_id"] = EmoteSetIds.ToArray()
            };
        }
    }
}

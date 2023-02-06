using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class DeleteVideosArgs : QueryMap<string[]>
    {
        public List<string> VideoIds { get; set; } = new List<string>();

        public DeleteVideosArgs() { }
        public DeleteVideosArgs(params string[] videoIds)
        {
            VideoIds = videoIds.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            return new Dictionary<string, string[]>
            {
                ["id"] = VideoIds.ToArray()
            };
        }
    }
}
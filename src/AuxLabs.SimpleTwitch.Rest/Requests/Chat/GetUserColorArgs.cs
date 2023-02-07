using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetUserColorArgs : QueryMap<string[]>
    {
        public List<string> UserIds { get; set; } = new List<string>();

        public GetUserColorArgs() { }
        public GetUserColorArgs(params string[] userIds)
        {
            UserIds = userIds.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            return new Dictionary<string, string[]>
            {
                ["user_id"] = UserIds.ToArray()
            };
        }
    }
}

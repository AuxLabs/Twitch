using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetUsersArgs : QueryMap<string[]>
    {
        /// <summary>  </summary>
        public List<string> UserIds { get; set; } = new List<string>();

        /// <summary>  </summary>
        public List<string> UserNames { get; set; } = new List<string>();

        public GetUsersArgs() { }
        public GetUsersArgs(GetUsersMode mode, params string[] users)
        {
            if (mode == GetUsersMode.Id)
                UserIds = users.ToList();
            else
                UserNames = users.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();
            if (UserIds.Count > 0)
            {
                var list = new List<string>();
                foreach (var id in UserIds)
                    list.Add(id);
                map["id"] = list.ToArray();
            }
            if (UserNames.Count > 0)
            {
                var list = new List<string>();
                foreach (var id in UserNames)
                    list.Add(id);
                map["login"] = list.ToArray();
            }
            return map;
        }
    }

    public enum GetUsersMode
    {
        Id,
        Name
    }
}

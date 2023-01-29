using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetUsersArgs : QueryMap<string[]>
    {
        /// <summary>  </summary>
        public IEnumerable<string> UserIds { get; set; } = null;

        /// <summary>  </summary>
        public IEnumerable<string> UserNames { get; set; } = null;

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
            if (UserIds != null)
            {
                var list = new List<string>();
                foreach (var id in UserIds)
                    list.Add(id);
                map["id"] = list.ToArray();
            }
            if (UserNames != null)
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

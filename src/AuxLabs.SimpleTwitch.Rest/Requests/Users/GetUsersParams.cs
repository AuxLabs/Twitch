using RestEase;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetUsersParams : QueryMap<string[]>, IScoped
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> UserIds { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> UserNames { get; set; } = null;

        public GetUsersParams() { }
        public GetUsersParams(GetUsersMode mode, params string[] users)
        {
            switch (mode)
            {
                case GetUsersMode.Id:
                    UserIds = new List<string>(users);
                    break;
                case GetUsersMode.Name:
                    UserNames = new List<string>(users);
                    break;
            }
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

using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetUsersArgs : QueryMap
    {
        /// <summary> The ID of the user to get. </summary>
        public List<string> UserIds { get; set; }

        /// <summary> The login name of the user to get. </summary>
        public List<string> UserNames { get; set; }

        public GetUsersArgs() { }
        public GetUsersArgs(GetUsersMode mode, params string[] users)
        {
            if (mode == GetUsersMode.Id)
                UserIds = users.ToList();
            else
                UserNames = users.ToList();
        }

        public void Validate()
        {
            int? total = UserIds?.Count + UserNames?.Count;
            Require.AtMost(total, 100, nameof(total), $"The combined item total of [{nameof(UserIds)}, {nameof(UserNames)}] must be at most 100");
            Require.HasAtLeast(UserIds, 1, nameof(UserIds));
            Require.HasAtLeast(UserNames, 1, nameof(UserNames));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            if (UserIds != null)
            {
                foreach (var item in UserIds)
                    map["id"] = item;
            }
            if (UserNames != null)
            {
                foreach (var item in UserNames)
                    map["login"] = item;
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

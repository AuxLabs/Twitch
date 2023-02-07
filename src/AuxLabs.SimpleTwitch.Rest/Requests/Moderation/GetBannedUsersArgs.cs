using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetBannedUsersArgs : QueryMap<string[]>, IScoped, IPaginated
    {
        public string[] Scopes { get; } = { "moderation:read", "moderator:manage:banned_users" };

        /// <summary> The ID of the broadcaster whose list of banned users you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> A list of user IDs used to filter the results. </summary>
        public List<string> UserIds { get; set; } = new List<string>();

        public int? First { get; set; }
        public string Before { get; set; }
        public string After { get; set; }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>()
            {
                ["broadcaster_id"] = new[] { BroadcasterId }
            };

            if (UserIds.Count > 0)
                map["user_id"] = UserIds.ToArray();
            if (First != null)
                map["first"] = new[] { First.Value.ToString() };
            if (Before != null)
                map["before"] = new[] { Before };
            if (After != null)
                map["after"] = new[] { After };

            return map;
        }
    }
}

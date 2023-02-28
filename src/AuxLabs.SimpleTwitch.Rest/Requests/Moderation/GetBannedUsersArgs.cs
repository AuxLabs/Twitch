using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetBannedUsersArgs : QueryMap, IPaginatedRequest, IAgentRequest
    {
        public string[] Scopes { get; } = { "moderation:read", "moderator:manage:banned_users" };

        /// <summary> The ID of the broadcaster whose list of banned users you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> A list of user IDs used to filter the results. </summary>
        public List<string> UserIds { get; set; }

        public int? First { get; set; }
        public string Before { get; set; }
        public string After { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.HasAtLeast(UserIds, 1, nameof(UserIds));
            Require.HasAtMost(UserIds, 100, nameof(UserIds));

            Require.Exclusive(new object[] { Before, After }, new[] { nameof(Before), nameof(After) });
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(Before, nameof(Before));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);
            
            if (BroadcasterId != null) 
                map["broadcaster_id"] = BroadcasterId;
            if (UserIds?.Count > 0)
            {
                foreach (var item in UserIds)
                    map["user_id"] = item;
            }
            if (First != null)
                map["first"] = First.Value.ToString();
            if (Before != null)
                map["before"] = Before;
            if (After != null)
                map["after"] = After;

            return map;
        }
    }
}

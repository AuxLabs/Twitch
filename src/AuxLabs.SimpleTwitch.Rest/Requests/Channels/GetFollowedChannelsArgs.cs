using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetFollowedChannelsArgs : GetFollowsArgs, IManaged
    {
        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(UserId, authedUserId, nameof(UserId), $"Value must be the authenticated user's id.");
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["user_id"] = UserId
            };

            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }
    }
}

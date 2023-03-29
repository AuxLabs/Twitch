using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetFollowersArgs : GetFollowsArgs, IAgentRequest
    {
        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };

            if (UserId != null)
                map["user_id"] = UserId;
            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }
    }
}

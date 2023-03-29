using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class ManageModeratorArgs : ManageRolesArgs, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:moderators" };

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Validate();
            Require.Scopes(scopes, Scopes);
        }
    }
}

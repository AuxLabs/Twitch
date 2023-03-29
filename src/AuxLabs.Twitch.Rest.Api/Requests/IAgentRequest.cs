using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public interface IAgentRequest : IScopedRequest
    {
        void Validate(IEnumerable<string> scopes, string authedUserId);
    }
}

using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public interface IAgentRequest : IScopedRequest
    {
        void Validate(IEnumerable<string> scopes, string authedUserId);
    }
}

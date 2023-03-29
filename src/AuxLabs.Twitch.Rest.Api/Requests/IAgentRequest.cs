using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public interface IAgentRequest : IScopedRequest
    {
        void Validate(IEnumerable<string> scopes, string authedUserId);
    }
}

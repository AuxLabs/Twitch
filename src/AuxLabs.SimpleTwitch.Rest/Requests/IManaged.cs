using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public interface IManaged : IScoped
    {
        void Validate(IEnumerable<string> scopes, string authedUserId);
    }
}

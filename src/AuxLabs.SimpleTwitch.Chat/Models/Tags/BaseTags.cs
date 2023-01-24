using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public abstract class BaseTags : QueryMap
    {
        public abstract void LoadQueryMap(IReadOnlyDictionary<string, string> map);
    }
}

using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Chat
{
    public abstract class BaseTags : QueryMap
    {
        /// <summary> Fill a dictionary with tags in their query format. </summary>
        public abstract void LoadQueryMap(IReadOnlyDictionary<string, string> map);
    }
}

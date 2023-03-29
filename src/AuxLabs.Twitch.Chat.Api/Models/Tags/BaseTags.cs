using System.Collections.Generic;

namespace AuxLabs.Twitch.Chat.Models
{
    public abstract class BaseTags : QueryMap
    {
        /// <summary> Fill a dictionary with tags in their query format. </summary>
        public abstract void LoadQueryMap(IReadOnlyDictionary<string, string> map);
    }
}

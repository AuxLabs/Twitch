namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public abstract class BaseTags : QueryMap
    {
        public abstract void LoadQueryMap(IReadOnlyDictionary<string, string> map);
    }
}

namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class ClearChatEventArgs
    {
        public ClearChatTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string UserName { get; set; }
    }
}

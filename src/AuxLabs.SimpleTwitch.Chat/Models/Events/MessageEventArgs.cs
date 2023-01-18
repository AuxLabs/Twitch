namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class MessageEventArgs
    {
        public MessageTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}

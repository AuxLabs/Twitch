namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class NoticeEventArgs
    {
        public NoticeTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string Message { get; set; }
    }
}

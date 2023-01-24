namespace AuxLabs.SimpleTwitch.Chat
{
    public class NoticeEventArgs
    {
        public NoticeTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string Message { get; set; }

        public NoticeEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.LastOrDefault().Trim(':');
        }
    }
}

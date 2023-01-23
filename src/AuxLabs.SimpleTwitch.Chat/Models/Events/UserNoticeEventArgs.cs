namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class UserNoticeEventArgs
    {
        public UserNoticeTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string Message { get; set; }

        public UserNoticeEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.ElementAtOrDefault(1)?.Trim(':');
        }
    }
}

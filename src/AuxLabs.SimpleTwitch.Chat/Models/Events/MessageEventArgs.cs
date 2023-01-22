namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class MessageEventArgs
    {
        public MessageTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }

        public MessageEventArgs(IrcPrefix? prefix, IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.LastOrDefault().Trim(':');
            UserName = prefix?.Username;
        }
    }
}

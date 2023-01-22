namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class ClearChatEventArgs
    {
        public ClearChatTags Tags { get; set; }
        public string ChannelName { get; set; }
        public string UserName { get; set; }

        public ClearChatEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            UserName = parameters.ElementAtOrDefault(1)?.Trim(':');
        }
    }
}

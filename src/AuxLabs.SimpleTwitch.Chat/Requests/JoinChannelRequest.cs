namespace AuxLabs.SimpleTwitch.Chat.Requests
{
    public class JoinChannelRequest : IrcMessage
    {
        public JoinChannelRequest() { }
        public JoinChannelRequest(string channelName)
        {
            Command = IrcCommand.Join;
            Parameters = $"#{channelName}";
        }
    }
}

namespace AuxLabs.SimpleTwitch.Chat.Requests
{
    public class JoinChannelRequest : IrcPayload
    {
        public JoinChannelRequest() { }
        public JoinChannelRequest(string channelName)
        {
            Command = IrcCommand.Join;
            Parameters = new[] { $"#{channelName}" };
        }
    }
}

namespace AuxLabs.SimpleTwitch.Chat
{
    public class JoinChannelRequest : IrcPayload
    {
        public JoinChannelRequest() { }
        public JoinChannelRequest(string channelName)
        {
            Require.NotNullOrWhitespace(channelName, nameof(channelName));

            Command = IrcCommand.Join;
            Parameters = new[] { $"#{channelName}" };
        }
    }
}

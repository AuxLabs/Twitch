namespace AuxLabs.SimpleTwitch.Chat
{
    public class PartChannelRequest : IrcPayload
    {
        public PartChannelRequest() { }
        public PartChannelRequest(string channelName)
        {
            Require.NotNullOrWhitespace(channelName, nameof(channelName));

            Command = IrcCommand.Part;
            Parameters = new[] { $"#{channelName}" };
        }
    }
}

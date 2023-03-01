namespace AuxLabs.SimpleTwitch.Chat
{
    public class JoinChannelsRequest : IrcPayload
    {
        public JoinChannelsRequest() { }
        public JoinChannelsRequest(params string[] channelNames)
        {
            Require.HasAtLeast(channelNames, 1, nameof(channelNames));
            Require.HasAtMost(channelNames, 20, nameof(channelNames));

            for (int i = 0; i < channelNames.Length; i++)
            {
                Require.NotNullOrWhitespace(channelNames[i], nameof(channelNames));
                if (!channelNames[i].StartsWith('#'))
                    channelNames[i] = channelNames[i].Insert(0, "#");
            }

            Command = IrcCommand.Join;
            Parameters = new[] { string.Join(",", channelNames) };
        }
    }
}

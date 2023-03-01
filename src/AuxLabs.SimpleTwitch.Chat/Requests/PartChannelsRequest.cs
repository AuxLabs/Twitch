namespace AuxLabs.SimpleTwitch.Chat
{
    public class PartChannelsRequest : IrcPayload
    {
        public PartChannelsRequest() { }
        public PartChannelsRequest(params string[] channelNames)
        {
            //Require.HasAtLeast(channelNames, 1, nameof(channelNames));
            //Require.HasAtMost(channelNames, 20, nameof(channelNames));

            for (int i = 0; i < channelNames.Length; i++)
            {
                Require.NotNullOrWhitespace(channelNames[i], nameof(channelNames));
                if (!channelNames[i].StartsWith('#'))
                    channelNames[i] = channelNames[i].Insert(0, "#");
            }

            Command = IrcCommand.Part;
            Parameters = new[] { string.Join(",", channelNames) };
        }
    }
}

namespace AuxLabs.SimpleTwitch.Chat
{
    public class SendMessageRequest : IrcPayload
    {
        public SendMessageRequest(string channelName, string message, string replyMessageId = null)
        {
            Require.NotNullOrWhitespace(channelName, nameof(channelName));
            Require.NotNullOrWhitespace(message, nameof(message));
            Require.LengthAtLeast(message, 1, nameof(message));
            Require.LengthAtMost(message, 500, nameof(message));
            Require.NotEmptyOrWhitespace(replyMessageId, nameof(replyMessageId));

            if (replyMessageId != null)
                Tags = new SendMessageTags(replyMessageId);

            Command = IrcCommand.Message;
            var parameters = new[]
            {
                $"#{channelName}",
                $" :{message}"
            };
            Parameters = parameters;
        }
    }
}

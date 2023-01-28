using System;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class SendMessageRequest : IrcPayload
    {
        public SendMessageRequest(string channelName, string message, string replyMessageId = null)
        {
            Command = IrcCommand.Message;

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));
            if (replyMessageId != null)
                Tags = new SendMessageTags(replyMessageId);

            var parameters = new[]
            {
                $"#{channelName}",
                $" :{message}"
            };
            Parameters = parameters;
        }
    }
}

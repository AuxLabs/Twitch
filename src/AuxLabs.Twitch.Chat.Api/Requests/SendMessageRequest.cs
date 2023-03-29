using AuxLabs.Twitch.Chat.Api;
using AuxLabs.Twitch.Chat.Models;
using System.Threading;

namespace AuxLabs.Twitch.Chat.Requests
{
    public class SendMessageRequest : BaseChatRequest
    {
        public string ChannelName { get; set; }
        public string Message { get; set; }
        public string ReplyMessageId { get; set; } = null;

        public SendMessageRequest(string channelName, string message, string replyMessageId = null)
        {
            ChannelName = channelName;
            Message = message;
            ReplyMessageId = replyMessageId;
        }
        public SendMessageRequest(string channelName, string message, string replyMessageId = null, CancellationToken? cancelToken = null)
            : this(channelName, message, replyMessageId)
        {
            CancellationToken = cancelToken ?? CancellationToken.None;
        }

        public override void Validate(bool verified)
        {
            Require.NotNullOrWhitespace(ChannelName, nameof(ChannelName));
            Require.NotNullOrWhitespace(Message, nameof(Message));
            Require.LengthAtLeast(Message, 1, nameof(Message));
            Require.LengthAtMost(Message, 500, nameof(Message));
            Require.NotEmptyOrWhitespace(ReplyMessageId, nameof(ReplyMessageId));
        }

        public override IrcPayload CreateRequest()
        {
            var payload = new IrcPayload();
            if (ReplyMessageId != null)
                payload.Tags = new SendMessageTags(ReplyMessageId);

            payload.Command = IrcCommand.Message;
            var parameters = new[]
            {
                $"#{ChannelName}",
                $" :{Message}"
            };
            payload.Parameters = parameters;
            return payload;
        }
    }
}

using System;

namespace AuxLabs.SimpleTwitch.Chat
{
    public interface IChatMessage : IMessage
    {
        DateTimeOffset Timestamp { get; }

        string ChannelId { get; }
        string ChannelName { get; }
        string BadgeInfo { get; }
        string Nonce { get; }

        string CustomRewardId { get; }

        string ReplyMessageId { get; }
        string ReplyMessageContent { get; }
        string ReplyAuthorId { get; }
        string ReplyAuthorName { get; }
        string ReplyAuthorDisplayName { get; }

        int BitsAmount { get; }

        bool IsModerator { get; }
        bool IsSubscriber { get; }
        bool IsVip { get; }
        bool IsFirstMessage { get; }
        bool IsEmoteOnly { get; }

        MessageType MessageType { get; }
    }
}

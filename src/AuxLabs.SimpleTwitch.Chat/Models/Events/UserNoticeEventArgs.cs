using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class UserNoticeEventArgs : IUserNoticeMessage
    {
        public UserNoticeTags Tags { get; internal set; }
        public string ChannelName { get; internal set; }
        public string Message { get; internal set; }

        public UserNoticeEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.ElementAtOrDefault(1)?.Trim(':');
        }

        public static UserNoticeEventArgs Create(IrcPayload payload)
        {
            var args = new UserNoticeEventArgs(payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (UserNoticeTags)payload.Tags;
            return args;
        }

        UserNoticeType IUserNoticeMessage.NoticeType => Tags.NoticeType;
        string IUserNoticeMessage.SystemMessage => Tags.SystemMessage;

        DateTimeOffset IChatMessage.Timestamp => Tags.Timestamp;
        string IChatMessage.ChannelId => Tags.ChannelId;
        string IChatMessage.BadgeInfo => Tags.BadgeInfo;
        string IChatMessage.Nonce => Tags.Nonce;
        string IChatMessage.CustomRewardId => Tags.CustomRewardId;
        string IChatMessage.ReplyMessageId => Tags.ReplyMessageId;
        string IChatMessage.ReplyMessageContent => Tags.ReplyMessageContent;
        string IChatMessage.ReplyAuthorId => Tags.ReplyAuthorId;
        string IChatMessage.ReplyAuthorName => Tags.ReplyAuthorName;
        string IChatMessage.ReplyAuthorDisplayName => Tags.ReplyAuthorDisplayName;
        int IChatMessage.BitsAmount => Tags.BitsAmount;
        bool IChatMessage.IsModerator => Tags.IsModerator;
        bool IChatMessage.IsSubscriber => Tags.IsSubscriber;
        bool IChatMessage.IsVip => Tags.IsVIP;
        bool IChatMessage.IsFirstMessage => Tags.IsFirstMessage;
        bool IChatMessage.IsEmoteOnly => Tags.IsEmoteOnly;
        MessageType IChatMessage.MessageType => Tags.MessageType;
        string IMessage.AuthorId => Tags.AuthorId;
        string IMessage.AuthorName => Tags.AuthorName;
        string IMessage.AuthorDisplayName => Tags.AuthorDisplayName;
        string IMessage.Content => Message;
        string IMessage.Action => Tags.Action;
        bool IMessage.IsTurbo => Tags.IsTurbo;
        Color IMessage.AuthorColor => Tags.AuthorColor;
        UserType IMessage.AuthorType => Tags.AuthorType;
        IReadOnlyCollection<Badge> IMessage.Badges => Tags.Badges;
        IReadOnlyCollection<EmotePosition> IMessage.Emotes => Tags.Emotes;
        string IEntity<string>.Id => Tags.NoticeType.GetStringValue();
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace AuxLabs.Twitch.Chat
{
    public class MessageEventArgs : IChatMessage
    {
        /// <summary> If special characters are present, emote indices will be incorrect. </summary>
        public readonly bool ContainsSpecialCharacters;

        public MessageTags Tags { get; internal set; }
        public string ChannelName { get; internal set; }
        public string UserName { get; internal set; }
        public string Message { get; internal set; }

        public MessageEventArgs(IrcPrefix? prefix, IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.LastOrDefault()[1..];
            UserName = prefix?.Username;
            ContainsSpecialCharacters = new StringInfo(Message).LengthInTextElements < Message.Length;
        }

        public static MessageEventArgs Create(IrcPayload payload)
        {
            var args = new MessageEventArgs(payload.Prefix, payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (MessageTags)payload.Tags;
            return args;
        }

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
        string IEntity<string>.Id => Tags.MessageId;
        string IMessage.AuthorId => Tags.AuthorId;
        string IMessage.AuthorName => UserName;
        string IMessage.AuthorDisplayName => Tags.AuthorDisplayName;
        string IMessage.Content => Message;
        string IMessage.Action => Tags.Action;
        bool IMessage.IsTurbo => Tags.IsTurbo;
        Color IMessage.AuthorColor => Tags.AuthorColor;
        UserType IMessage.AuthorType => Tags.AuthorType;
        IReadOnlyCollection<Badge> IMessage.Badges => Tags.Badges;
        IReadOnlyCollection<EmotePosition> IMessage.Emotes => Tags.Emotes;
    }
}

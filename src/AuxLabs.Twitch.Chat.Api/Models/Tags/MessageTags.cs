using System;
using System.Collections.Generic;
using System.Drawing;

namespace AuxLabs.Twitch.Chat
{
    public class MessageTags : BaseTags
    {
        /// <summary> The date and time that the message was sent. </summary>
        public DateTimeOffset Timestamp { get; internal set; }

        /// <summary> An ID that uniquely identifies the message. </summary>
        public string MessageId { get; internal set; }

        /// <summary> An ID that identifies the channel. </summary>
        public string ChannelId { get; internal set; }

        /// <summary> The ID of the user that sent the message. </summary>
        public string AuthorId { get; internal set; }

        /// <summary> The user’s login name. </summary>
        public string AuthorName { get; internal set; }

        /// <summary> The user’s display name. </summary>
        public string AuthorDisplayName { get; internal set; }

        /// <summary> The type of user. </summary>
        public UserType AuthorType { get; internal set; }

        /// <summary> The color of the user’s name in the chat room. </summary>
        public Color AuthorColor { get; internal set; }

        /// <summary> A unique value used to identify requests </summary>
        public string Nonce { get; internal set; }

        /// <summary>  </summary>
        public string CustomRewardId { get; internal set; }

        /// <summary> An ID that uniquely identifies the parent message that this message is replying to. </summary>
        public string ReplyMessageId { get; internal set; }

        /// <summary> The text of the parent message. </summary>
        public string ReplyMessageContent { get; internal set; }

        /// <summary> An ID that identifies the sender of the parent message. </summary>
        public string ReplyAuthorId { get; internal set; }

        /// <summary> The login name of the sender of the parent message. </summary>
        public string ReplyAuthorName { get; internal set; }

        /// <summary> The display name of the sender of the parent message. </summary>
        public string ReplyAuthorDisplayName { get; internal set; }

        /// <summary> The amount of Bits the user cheered. Only a Bits cheer message includes this tag. </summary>
        public int BitsAmount { get; internal set; }

        /// <summary> Indicates whether the user is a moderator. </summary>
        public bool IsModerator { get; internal set; }

        /// <summary> Indicates whether the user is a subscriber. </summary>
        public bool IsSubscriber { get; internal set; }

        /// <summary> Indicates whether the user has site-wide commercial free mode enabled. </summary>
        public bool IsTurbo { get; internal set; }

        /// <summary> Indicates whether the user is a VIP. </summary>
        public bool IsVIP { get; internal set; }

        /// <summary> Indicates whether this is the user's first message in the channel </summary>
        public bool IsFirstMessage { get; internal set; }

        /// <summary> Indicates whether this message contains only emotes </summary>
        public bool IsEmoteOnly { get; internal set; }

        /// <summary> A value that indicates if a message has unique properties </summary>
        public MessageType MessageType { get; internal set; }

        /// <summary> A collection of badges the user has. </summary>
        public IReadOnlyCollection<Badge> Badges { get; internal set; }

        /// <summary> Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber. </summary>
        public string BadgeInfo { get; internal set; }

        /// <summary> A collection of emotes and their position in the message. </summary>
        public IReadOnlyCollection<EmotePosition> Emotes { get; internal set; }

        /// <summary> The message value when someone uses the /me chat command </summary>
        public string Action { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["id"] = MessageId,
                ["custom-reward-id"] = CustomRewardId,
                ["room-id"] = ChannelId,
                ["msg-id"] = MessageType.GetStringValue(),
                ["tmi-sent-ts"] = Timestamp.ToUnixTimeMilliseconds().ToString(),
                ["user-id"] = AuthorId,
                ["user-type"] = EnumHelper.GetStringValue(AuthorType),
                ["display-name"] = AuthorDisplayName,
                ["login"] = AuthorName,
                ["color"] = ColorTranslator.ToHtml(AuthorColor),
                ["badges"] = Badges == null ? null : string.Join(',', Badges),
                ["badge-info"] = BadgeInfo,
                ["bits"] = BitsAmount.ToString(),
                ["emotes"] = Emotes == null ? Action : string.Join(',', Emotes),
                ["mod"] = IsModerator ? "1" : "0",
                ["subscriber"] = IsSubscriber ? "1" : "0",
                ["turbo"] = IsTurbo ? "1" : "0",
                ["vip"] = IsVIP ? "1" : "0",
                ["emote-only"] = IsEmoteOnly ? "1" : "0",
                ["first-msg"] = IsFirstMessage ? "1" : "0",
                ["reply-parent-msg-id"] = ReplyMessageId,
                ["reply-parent-user-id"] = ReplyAuthorId,
                ["reply-parent-user-login"] = ReplyAuthorName,
                ["reply-parent-display-name"] = ReplyAuthorDisplayName,
                ["reply-parent-msg-body"] = ReplyMessageContent?.Replace(" ", "\\s"),
                ["client-nonce"] = Nonce
            };
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("id", out string str))
                MessageId = str;
            if (map.TryGetValue("custom-reward-id", out str))
                CustomRewardId = str;
            if (map.TryGetValue("room-id", out str))
                ChannelId = str;
            if (map.TryGetValue("msg-id", out str))
                MessageType = EnumHelper.GetEnumValue<MessageType>(str);
            if (map.TryGetValue("tmi-sent-ts", out str))
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(str));
            if (map.TryGetValue("user-id", out str))
                AuthorId = str;
            if (map.TryGetValue("user-type", out str))
                AuthorType = EnumHelper.GetEnumValue<UserType>(str);
            if (map.TryGetValue("display-name", out str))
                AuthorDisplayName = str;
            if (map.TryGetValue("login", out str))
                AuthorName = str;
            if (map.TryGetValue("color", out str))
                AuthorColor = ColorTranslator.FromHtml(str);
            if (map.TryGetValue("badges", out str))
            {
                if (Badge.TryParseMany(str, out var badges))
                    Badges = badges;
            }
            if (map.TryGetValue("badge-info", out str))
                BadgeInfo = str;
            if (map.TryGetValue("bits", out str))
            {
                if (int.TryParse(str, out int bits))
                    BitsAmount = bits;
                else
                    BitsAmount = 0;
            }
            if (map.TryGetValue("emotes", out str))
            {
                if (EmotePosition.TryParseMany(str, out var emotes))
                    Emotes = emotes;
                else
                    Action = str;
            }
            if (map.TryGetValue("mod", out str))
                IsModerator = str == "1";
            if (map.TryGetValue("subscriber", out str))
                IsSubscriber = str == "1";
            if (map.TryGetValue("turbo", out str))
                IsTurbo = str == "1";
            if (map.TryGetValue("vip", out str))
                IsVIP = str == "1";
            if (map.TryGetValue("emote-only", out str))
                IsEmoteOnly = str == "1";
            if (map.TryGetValue("first-msg", out str))
                IsFirstMessage = str == "1";
            if (map.TryGetValue("reply-parent-msg-id", out str))
                ReplyMessageId = str;
            if (map.TryGetValue("reply-parent-user-id", out str))
                ReplyAuthorId = str;
            if (map.TryGetValue("reply-parent-user-login", out str))
                ReplyAuthorName = str;
            if (map.TryGetValue("reply-parent-display-name", out str))
                ReplyAuthorDisplayName = str;
            if (map.TryGetValue("reply-parent-msg-body", out str))
                ReplyMessageContent = str;
            if (map.TryGetValue("client-nonce", out str))
                Nonce = str;
        }
    }
}

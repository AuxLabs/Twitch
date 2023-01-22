﻿using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class MessageTags : BaseTags
    {
        /// <summary>
        /// An ID that uniquely identifies the message.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// An ID that identifies the channel.
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// The date and time that the message was sent.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The ID of the user that sent the message.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The type of user.
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// The user’s display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The color of the user’s name in the chat room.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// A collection of badges the user has.
        /// </summary>
        public IReadOnlyCollection<Badge> Badges { get; set; }

        /// <summary>
        /// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
        /// </summary>
        public string BadgeInfo { get; set; }

        /// <summary>
        /// The amount of Bits the user cheered. Only a Bits cheer message includes this tag.
        /// </summary>
        public int Bits { get; set; }

        /// <summary>
        /// A collection of emotes and their position in the message.
        /// </summary>
        public IReadOnlyCollection<EmotePosition> Emotes { get; set; }

        /// <summary>
        /// Indicates whether the user is a moderator.
        /// </summary>
        public bool IsMod { get; set; }

        /// <summary>
        /// Indicates whether the user is a subscriber.
        /// </summary>
        public bool IsSubscriber { get; set; }

        /// <summary>
        /// Indicates whether the user has site-wide commercial free mode enabled.
        /// </summary>
        public bool IsTurbo { get; set; }

        /// <summary>
        /// Indicates whether the user is a VIP.
        /// </summary>
        public bool IsVIP { get; set; }

        /// <summary>
        /// An ID that uniquely identifies the parent message that this message is replying to.
        /// </summary>
        public string ReplyParentMessageId { get; set; }

        /// <summary>
        /// An ID that identifies the sender of the parent message.
        /// </summary>
        public string ReplyParentUserId { get; set; }

        /// <summary>
        /// The login name of the sender of the parent message.
        /// </summary>
        public string ReplyParentUserLogin { get; set; }

        /// <summary>
        /// The display name of the sender of the parent message.
        /// </summary>
        public string ReplyParentDisplayName { get; set; }

        /// <summary>
        /// The text of the parent message.
        /// </summary>
        public string ReplyParentMessage { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["id"] = Id,
                ["room-id"] = ChannelId,
                ["tmi-sent-ts"] = Timestamp.ToUnixTimeMilliseconds().ToString(),
                ["user-id"] = UserId,
                ["user-type"] = EnumHelper.GetEnumMemberValue(UserType),
                ["display-name"] = DisplayName,
                ["color"] = ColorTranslator.ToHtml(Color),
                ["badges"] = string.Join(',', Badges),
                ["badge-info"] = BadgeInfo,
                ["bits"] = Bits.ToString(),
                ["emotes"] = string.Join(',', Emotes),
                ["mod"] = IsMod ? "1" : "0",
                ["subscriber"] = IsSubscriber ? "1" : "0",
                ["turbo"] = IsTurbo ? "1" : "0",
                ["vip"] = IsVIP ? "1" : "0",
                ["reply-parent-msg-id"] = ReplyParentMessageId,
                ["reply-parent-user-id"] = ReplyParentUserId,
                ["reply-parent-user-login"] = ReplyParentUserLogin,
                ["reply-parent-display-name"] = ReplyParentDisplayName,
                ["reply-parent-msg-body"] = ReplyParentMessage.Replace(" ", "\\s")
            };
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("id", out string str))
                Id = str;
            if (map.TryGetValue("room-id", out str))
                ChannelId = str;
            if (map.TryGetValue("tmi-sent-ts", out str))
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(str));
            if (map.TryGetValue("user-id", out str))
                UserId = str;
            if (map.TryGetValue("user-type", out str))
                UserType = EnumHelper.GetValueFromEnumMember<UserType>(str);
            if (map.TryGetValue("display-name", out str))
                DisplayName = str;
            if (map.TryGetValue("color", out str))
                Color = ColorTranslator.FromHtml(str);
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
                    Bits = bits;
                else
                    Bits = 0;
            }
            if (map.TryGetValue("emotes", out str))
            {
                if (EmotePosition.TryParseMany(str, out var emotes))
                    Emotes = emotes;
            }
            if (map.TryGetValue("mod", out str))
                IsMod = str == "1";
            if (map.TryGetValue("subscriber", out str))
                IsSubscriber = str == "1";
            if (map.TryGetValue("turbo", out str))
                IsTurbo = str == "1";
            if (map.TryGetValue("vip", out str))
                IsVIP = str == "1";
            if (map.TryGetValue("reply-parent-msg-id", out str))
                ReplyParentMessageId = str;
            if (map.TryGetValue("reply-parent-user-id", out str))
                ReplyParentUserId = str;
            if (map.TryGetValue("reply-parent-user-login", out str))
                ReplyParentUserLogin = str;
            if (map.TryGetValue("reply-parent-display-name", out str))
                ReplyParentDisplayName = str;
            if (map.TryGetValue("reply-parent-msg-body", out str))
                ReplyParentMessage = str;
        }
    }
}

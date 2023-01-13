using AuxLabs.SimpleTwitch.Chat.Serialization;
using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class MessageTags
    {
        /// <summary>
        /// An ID that uniquely identifies the message.
        /// </summary>
        [IrcTagName("id")]
        public string Id { get; set; }

        /// <summary>
        /// An ID that identifies the channel.
        /// </summary>
        [IrcTagName("room-id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// The date and time that the message was sent.
        /// </summary>
        [IrcTagName("tmi-sent-ts")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The ID of the user that sent the message.
        /// </summary>
        [IrcTagName("user-id")]
        public string UserId { get; set; }

        /// <summary>
        /// The type of user.
        /// </summary>
        [IrcTagName("user-type")]
        public UserType UserType { get; set; }

        /// <summary>
        /// The user’s display name.
        /// </summary>
        [IrcTagName("display-name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The color of the user’s name in the chat room.
        /// </summary>
        [IrcTagName("color")]
        public Color Color { get; set; }

        /// <summary>
        /// A collection of badges the user has.
        /// </summary>
        [IrcTagName("badges")]
        public IReadOnlyCollection<Badge> Badges { get; set; }

        /// <summary>
        /// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
        /// </summary>
        [IrcTagName("badge-info")]
        public string BadgeInfo { get; set; }

        /// <summary>
        /// The amount of Bits the user cheered. Only a Bits cheer message includes this tag.
        /// </summary>
        [IrcTagName("bits")]
        public int Bits { get; set; }

        /// <summary>
        /// A collection of emotes and their position in the message.
        /// </summary>
        [IrcTagName("emotes")]
        public IReadOnlyCollection<EmotePosition> Emotes { get; set; }

        /// <summary>
        /// Indicates whether the user is a moderator.
        /// </summary>
        [IrcTagName("mod")]
        public bool IsMod { get; set; }

        /// <summary>
        /// Indicates whether the user is a subscriber.
        /// </summary>
        [IrcTagName("subscriber")]
        public bool IsSubscriber { get; set; }

        /// <summary>
        /// Indicates whether the user has site-wide commercial free mode enabled.
        /// </summary>
        [IrcTagName("turbo")]
        public bool IsTurbo { get; set; }

        /// <summary>
        /// Indicates whether the user is a VIP.
        /// </summary>
        [IrcTagName("vip")]
        public bool IsVIP { get; set; }

        /// <summary>
        /// An ID that uniquely identifies the parent message that this message is replying to.
        /// </summary>
        [IrcTagName("reply-parent-msg-id")]
        public string ReplyParentMessageId { get; set; }

        /// <summary>
        /// An ID that identifies the sender of the parent message.
        /// </summary>
        [IrcTagName("reply-parent-user-id")]
        public string ReplyParentUserId { get; set; }

        /// <summary>
        /// The login name of the sender of the parent message.
        /// </summary>
        [IrcTagName("reply-parent-user-login")]
        public string ReplyParentUserLogin { get; set; }

        /// <summary>
        /// The display name of the sender of the parent message.
        /// </summary>
        [IrcTagName("reply-parent-display-name")]
        public string ReplyParentDisplayName { get; set; }

        /// <summary>
        /// The text of the parent message.
        /// </summary>
        [IrcTagName("reply-parent-msg-body")]
        public string ReplyParentMessage { get; set; }

    }
}

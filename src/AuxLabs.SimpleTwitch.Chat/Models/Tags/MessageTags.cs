using AuxLabs.SimpleTwitch.Chat.Serialization;

namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class MessageTags
    {
        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("room-id")]
        public string RoomId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("tmi-sent-ts")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("user-id")]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("user-type")]
        public string UserType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("display-name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("color")]
        public string Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("badges")]
        public string Badges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("badge-info")]
        public string BadgeInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("bits")]
        public int Bits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("emotes")]
        public string Emotes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("mod")]
        public bool IsMod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("subscriber")]
        public bool IsSubscriber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("turbo")]
        public bool IsTurbo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("vip")]
        public bool IsVIP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("reply-parent-msg-id")]
        public string ReplyParentMessageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("reply-parent-user-id")]
        public string ReplyParentUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("reply-parent-user-login")]
        public string ReplyParentUserLogin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("reply-parent-display-name")]
        public string ReplyParentDisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IrcTagName("reply-parent-msg-body")]
        public string ReplyParentMessage { get; set; }

    }
}

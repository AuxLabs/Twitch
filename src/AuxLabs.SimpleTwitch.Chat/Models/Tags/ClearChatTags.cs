namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class ClearChatTags
    {
        /// <summary>
        /// The date and time this event occurred.
        /// </summary>
        [IrcTagName("tmi-sent-ts")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The ID of the channel where the messages were removed from.
        /// </summary>
        [IrcTagName("room-id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// The ID of the user that was banned or put in a timeout.
        /// </summary>
        [IrcTagName("target-user-id")]
        public string TargetUserId { get; set; }

        /// <summary>
        /// The message includes this tag if the user was put in a timeout. The tag contains the duration of the timeout, in seconds.
        /// </summary>
        [IrcTagName("ban-duration")]
        public int BanDuration { get; set; }
    }
}

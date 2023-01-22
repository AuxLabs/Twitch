namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class ClearMessageTags : BaseTags
    {
        /// <summary>
        /// The date and time this event occurred.
        /// </summary>
        [IrcTagName("tmi-sent-ts")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// A UUID that identifies the message that was removed.
        /// </summary>
        [IrcTagName("target-msg-id")]
        public string TargetMessageId { get; set; }

        /// <summary>
        /// The name of the user who sent the message.
        /// </summary>
        [IrcTagName("login")]
        public string Login { get; set; }

        /// <summary>
        /// The ID of the channel (chat room) where the message was removed from.
        /// </summary>
        [IrcTagName("room-id")]
        public string ChannelId { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {

            };
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {

        }
    }
}

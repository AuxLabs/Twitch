namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class RoomStateTags : BaseTags
    {
        /// <summary>
        /// An ID that identifies the channel.
        /// </summary>
        [IrcTagName("room-id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// Indicates whether the chat room allows only messages with emotes.
        /// </summary>
        [IrcTagName("emote-only")]
        public bool IsEmoteOnly { get; set; }

        /// <summary>
        /// Indicates whether only followers can post messages in the chat room.
        /// </summary>
        public bool IsFollowersOnly => FollowersOnlyMinutes > -1;

        /// <summary>
        /// Indicates how long, in minutes, the user must have followed the broadcaster before posting chat messages.
        /// </summary>
        [IrcTagName("followers-only")]
        public int FollowersOnlyMinutes { get; set; }

        /// <summary>
        /// Indicates whether a user’s messages must be unique.
        /// </summary>
        [IrcTagName("r9k")]
        public bool IsR9k { get; set; }

        /// <summary>
        /// Indicates whether users must wait between sending messages.
        /// </summary>
        public bool IsSlow  => SlowSeconds > 0;

        /// <summary>
        /// Indicates how long, in seconds, users must wait between sending messages.
        /// </summary>
        [IrcTagName("slow")]
        public int SlowSeconds { get; set; }

        /// <summary>
        /// Indicates whether only subscribers and moderators can chat in the chat room.
        /// </summary>
        [IrcTagName("subs-only")]
        public bool IsSubsOnly { get; set; }

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

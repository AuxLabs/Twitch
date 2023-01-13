using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class GlobalUserStateTags
    {
        /// <summary>
        /// The user’s ID.
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
        /// A collection of IDs that identify the emote sets that the user has access to.
        /// </summary>
        [IrcTagName("emote-sets")]
        public IReadOnlyCollection<string> EmoteSets { get; set; }

        /// <summary>
        /// Indicates whether the user has site-wide commercial free mode enabled.
        /// </summary>
        [IrcTagName("turbo")]
        public bool IsTurbo { get; set; }
    }
}

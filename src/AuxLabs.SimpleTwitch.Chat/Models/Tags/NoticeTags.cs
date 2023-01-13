namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class NoticeTags
    {
        /// <summary>
        /// A value to determine the action’s outcome.
        /// </summary>
        [IrcTagName("msg-id")]
        public NoticeType NoticeType { get; set; }

        /// <summary>
        /// The ID of the user that the action targeted. If specified.
        /// </summary>
        [IrcTagName("target-user-id")]
        public string TargetUserId { get; set; }
    }
}

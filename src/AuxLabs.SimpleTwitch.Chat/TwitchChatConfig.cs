namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatConfig
    {
        /// <summary>
        /// Lets your bot send messages that include Twitch chat commands and receive Twitch-specific messages.
        /// </summary>
        public bool RequestCommands { get; init; }

        /// <summary>
        /// Lets your bot receive JOIN and PART events when users join and leave the chat room
        /// </summary>
        public bool RequestMembership { get; init; }

        /// <summary>
        /// Adds additional metadata to the command and membership messages.
        /// </summary>
        public bool RequestTags { get; init; }
    }
}

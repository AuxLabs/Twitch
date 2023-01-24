using AuxLabs.SimpleTwitch.Sockets;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatConfig
    {
        /// <summary>
        /// Lets your bot send messages that include Twitch chat commands and receive Twitch-specific messages.
        /// </summary>
        public bool RequestCommands { get; } = true;

        /// <summary>
        /// Lets your bot receive JOIN and PART events when users join and leave the chat room
        /// </summary>
        public bool RequestMembership { get; } = true;

        /// <summary>
        /// Adds additional metadata to the command and membership messages.
        /// </summary>
        public bool RequestTags { get; } = true;

        /// <summary>
        /// Should an exception be thrown if an unhandled event is received from twitch
        /// </summary>
        public bool ThrowOnUnknownCommand { get; } = false;

        /// <summary>
        /// Specify a custom serializer for chat irc messages
        /// </summary>
        public ISerializer<IrcPayload> IrcSerializer { get; } = null;
    }
}

using AuxLabs.SimpleTwitch.WebSockets;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class TwitchChatApiConfig
    {
        /// <summary> Lets your bot send messages that include Twitch chat commands and receive Twitch-specific messages. </summary>
        public bool RequestCommands { get; set; } = true;

        /// <summary> Lets your bot receive JOIN and PART events when users join and leave the chat room. </summary>
        public bool RequestMembership { get; set; } = false;

        /// <summary> Adds additional metadata to the command and membership messages. </summary>
        public bool RequestTags { get; set; } = true;

        /// <summary> Should the client forward event types to their respective events. </summary>
        public bool ShouldHandleEvents { get; set; } = true;

        /// <summary> Should an exception be raised if an unhandled event is received from twitch. </summary>
        public bool ThrowOnUnknownEvent { get; set; } = false;

        /// <summary> Should an exception be raised if an event provides unhandled tags </summary>
        public bool ThrowOnMismatchedTags { get; set; } = false;

        /// <summary> Specify a custom serializer for chat irc messages. </summary>
        public ISerializer<IrcPayload> IrcSerializer { get; set; } = null;
    }
}

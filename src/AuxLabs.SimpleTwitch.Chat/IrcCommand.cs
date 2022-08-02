using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Chat
{
    public enum IrcCommand
    {
        Unknown = 0,
        [EnumMember(Value = "CLEARCHAT")]   // Purge a user's messages
        ClearChat,
        [EnumMember(Value = "CLEARMSG")]    // Single message is removed
        ClearMessage,
        [EnumMember(Value = "HOSTTARGET")]  // Channel starts or stops hosting
        HostTarget,
        [EnumMember(Value = "PRIVMSG")]     // Send a message to a channel
        Message,

        [EnumMember(Value = "PONG")]        // Pong
        Pong,
        [EnumMember(Value = "MODE")]        // A moderator is added or removed from a channel
        Mode,
        [EnumMember(Value = "NAMES")]       // List current chatters in a channel
        Names,
        [EnumMember(Value = "NOTICE")]      // General notices from the server
        Notice,
        [EnumMember(Value = "RECONNECT")]   // Rejoin channels after a restart
        Reconnect,
        [EnumMember(Value = "ROOMSTATE")]   // Identifies a channel's current chat settings
        RoomState,
        [EnumMember(Value = "USERNOTICE")]  // Twitch-specific events in a channel
        UserNotice,
        [EnumMember(Value = "USERSTATE")]   // Identifies a user's current chat settings
        UserState,
        [EnumMember(Value = "CAP * ACK")]   // Response to cap req
        CapabilityAcknowledge,

        [EnumMember(Value = "PING")]        // Ping
        Ping,
        [EnumMember(Value = "PASS")]        // Password part of authorization
        Password,
        [EnumMember(Value = "NICK")]        // Nickname part of authorization
        Nickname,
        [EnumMember(Value = "CAP REQ")]     // Request a capability from the server (members/tags/commands)
        CapabilityRequest,
        [EnumMember(Value = "JOIN")]        // Join a channel
        Join,
        [EnumMember(Value = "PART")]        // Leave a channel
        Part
    }
}

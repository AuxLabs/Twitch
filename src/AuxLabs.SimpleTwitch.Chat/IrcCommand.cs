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
        [EnumMember(Value = "PRIVMSG")]     // Send a message to a channel
        Message,
        [EnumMember(Value = "WHISPER")]     // Send a message to a user
        Whisper,

        [EnumMember(Value = "PONG")]        // Pong
        Pong,
        [EnumMember(Value = "MODE")]        // A moderator is added or removed from a channel
        Mode,
        [EnumMember(Value = "NAMES")]       // List current chatters in a channel
        Names,
        [EnumMember(Value = "353")]         // Repeating list of names until 366
        NamesList,
        [EnumMember(Value = "366")]         // End of names list
        NamesEnd,
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
        [EnumMember(Value = "GLOBALUSERSTATE")]   // Provides user info on login
        GlobalUserState,
        [EnumMember(Value = "CAP * ACK")]   // Response to cap req
        CapabilityAcknowledge,
        [EnumMember(Value = "CAP * NAK")]   // Response to denied cap req
        CapabilityDenied,

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
        Part,

        [EnumMember(Value = "001")]
        RPL_Welcome,
        [EnumMember(Value = "002")]
        RPL_YourHost,
        [EnumMember(Value = "003")]
        RPL_Created,
        [EnumMember(Value = "004")]
        RPL_MyInfo,
        [EnumMember(Value = "375")]
        RPL_MotdStart,
        [EnumMember(Value = "372")]
        RPL_Motd,
        [EnumMember(Value = "376")]
        RPL_MotdEnd
    }
}

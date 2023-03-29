using System.Runtime.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public enum MessageType
    {
        Unknown = 0,

        [EnumMember(Value = "session_welcome")]
        Welcome,
        [EnumMember(Value = "session_keepalive")]
        KeepAlive,
        [EnumMember(Value = "session_reconnect")]
        Reconnect,
        [EnumMember(Value = "revocation")]
        Revocation,
        [EnumMember(Value = "notification")]
        Notification
    }
}

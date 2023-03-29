using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Chat
{
    public enum MessageType
    {
        Normal = 0,

        [EnumMember(Value = "highlighted-message")]
        Highlighted
    }
}

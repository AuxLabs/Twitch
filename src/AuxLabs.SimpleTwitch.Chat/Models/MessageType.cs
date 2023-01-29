using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Chat
{
    public enum MessageType
    {
        Normal = 0,

        [EnumMember(Value = "highlighted-message")]
        Highlighted
    }
}

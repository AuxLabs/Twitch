using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Chat
{
    public enum UserType
    {
        [EnumMember(Value = "")]
        Normal = 0,

        [EnumMember(Value = "admin")]
        Admin,

        [EnumMember(Value = "global_mod")]
        GlobalModerator,

        [EnumMember(Value = "staff")]
        Staff
    }
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<UserType>))]
    public enum UserType
    {
        None = 0,
        [EnumMember(Value = "staff")]
        Staff,
        [EnumMember(Value = "admin")]
        Admin,
        [EnumMember(Value = "global_mod")]
        GlobalModerator
    }
}

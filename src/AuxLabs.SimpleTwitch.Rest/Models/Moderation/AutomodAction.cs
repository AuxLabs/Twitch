using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum AutomodAction
    {
        [EnumMember(Value = "DENY")]
        Deny = 0,
        [EnumMember(Value = "ALLOW")]
        Allow
    }
}

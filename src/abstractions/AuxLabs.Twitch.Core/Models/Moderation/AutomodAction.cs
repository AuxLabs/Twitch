using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum AutomodAction
    {
        [EnumMember(Value = "DENY")]
        Deny = 0,
        [EnumMember(Value = "ALLOW")]
        Allow
    }
}

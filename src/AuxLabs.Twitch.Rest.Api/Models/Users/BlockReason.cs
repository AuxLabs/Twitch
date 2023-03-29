using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public enum BlockReason
    {
        [EnumMember(Value = "other")]
        Other = 0,

        [EnumMember(Value = "harassment")]
        Harassment,
        [EnumMember(Value = "spam")]
        Spam
    }
}

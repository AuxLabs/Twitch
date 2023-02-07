using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
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

using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum RedemptionStatus
    {
        Unknown = 0,

        [EnumMember(Value = "CANCELED")]
        Cancelled,
        [EnumMember(Value = "FULFILLED")]
        Fulfilled,
        [EnumMember(Value = "UNFULFILLED")]
        Unfulfilled
    }
}

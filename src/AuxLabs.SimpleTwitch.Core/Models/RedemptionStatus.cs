using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch
{
    public enum RedemptionStatus
    {
        [EnumMember(Value = "UNFULFILLED")]
        Unfulfilled = 0,

        [EnumMember(Value = "CANCELED")]
        Cancelled,
        [EnumMember(Value = "FULFILLED")]
        Fulfilled
    }
}

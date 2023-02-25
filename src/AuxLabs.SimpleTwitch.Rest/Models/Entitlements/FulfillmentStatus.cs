using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum FulfillmentStatus
    {
        [EnumMember(Value = "CLAIMED")]
        Claimed,

        [EnumMember(Value = "FULFILLED")]
        Fulfilled
    }
}

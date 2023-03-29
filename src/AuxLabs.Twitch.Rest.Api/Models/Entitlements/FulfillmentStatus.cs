using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum FulfillmentStatus
    {
        [EnumMember(Value = "CLAIMED")]
        Claimed,

        [EnumMember(Value = "FULFILLED")]
        Fulfilled
    }
}

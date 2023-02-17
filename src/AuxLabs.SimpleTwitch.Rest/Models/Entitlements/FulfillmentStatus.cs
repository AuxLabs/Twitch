using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<FulfillmentStatus>))]
    public enum FulfillmentStatus
    {
        [EnumMember(Value = "CLAIMED")]
        Claimed,

        [EnumMember(Value = "FULFILLED")]
        Fulfilled
    }
}

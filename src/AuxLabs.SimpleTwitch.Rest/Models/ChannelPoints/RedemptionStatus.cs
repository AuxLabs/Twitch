using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<RedemptionStatus>))]
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

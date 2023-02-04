using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<RedemptionSort>))]
    public enum RedemptionSort
    {
        [EnumMember(Value = "OLDEST")]
        Oldest = 0,
        [EnumMember(Value = "NEWEST")]
        Newest
    }
}

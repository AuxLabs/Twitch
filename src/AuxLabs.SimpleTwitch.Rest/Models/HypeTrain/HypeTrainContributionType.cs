using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<HypeTrainContributionType>))]
    public enum HypeTrainContributionType
    {
        [EnumMember(Value = "OTHER")]
        Other = 0,
        [EnumMember(Value = "BITS")]
        Bits,
        [EnumMember(Value = "SUBS")]
        Subscriptions
    }
}

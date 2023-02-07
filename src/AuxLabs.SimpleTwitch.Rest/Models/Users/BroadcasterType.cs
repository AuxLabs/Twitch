using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<BroadcasterType>))]
    public enum BroadcasterType
    {
        [EnumMember(Value = "")]
        None = 0,

        [EnumMember(Value = "partner")]
        Partner,

        [EnumMember(Value = "affiliate")]
        Affiliate
    }
}

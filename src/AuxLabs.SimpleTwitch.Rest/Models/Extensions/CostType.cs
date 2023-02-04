using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<CostType>))]
    public enum CostType
    {
        None = 0,

        [EnumMember(Value = "bits")]
        Bits
    }
}

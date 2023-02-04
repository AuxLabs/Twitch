using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<AnalyticType>))]
    public enum AnalyticType
    {
        None = 0,

        [EnumMember(Value = "overview_v2")]
        OverviewV2
    }
}

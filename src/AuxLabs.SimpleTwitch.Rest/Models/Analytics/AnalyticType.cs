using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum AnalyticType
    {
        None = 0,

        [EnumMember(Value = "overview_v2")]
        OverviewV2
    }
}

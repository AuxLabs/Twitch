using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum AnalyticType
    {
        None = 0,

        [EnumMember(Value = "overview_v2")]
        OverviewV2
    }
}

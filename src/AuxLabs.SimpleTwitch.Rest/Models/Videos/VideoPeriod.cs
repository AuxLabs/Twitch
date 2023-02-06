using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum VideoPeriod
    {
        All = 0,

        [EnumMember(Value = "day")]
        Day,
        [EnumMember(Value = "month")]
        Month,
        [EnumMember(Value = "week")]
        Week
    }
}

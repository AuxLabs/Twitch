using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum BitsPeriod
    {
        [EnumMember(Value = "all")]
        All = 0,
        [EnumMember(Value = "day")]
        Day,
        [EnumMember(Value = "week")]
        Week,
        [EnumMember(Value = "month")]
        Month,
        [EnumMember(Value = "year")]
        Year
    }
}

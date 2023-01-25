using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum BitsPeriod
    {
        All,
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

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<VideoPeriod>))]
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

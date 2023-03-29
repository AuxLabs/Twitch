using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum VideoSort
    {
        [EnumMember(Value = "time")]
        Time = 0,

        [EnumMember(Value = "trending")]
        Trending,
        [EnumMember(Value = "views")]
        Views
    }
}

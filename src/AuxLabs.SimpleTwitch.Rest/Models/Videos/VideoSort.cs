using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
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

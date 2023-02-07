using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<VideoSort>))]
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

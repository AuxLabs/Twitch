using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<BroadcastType>))]
    public enum BroadcastType
    {
        Unknown = 0,

        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "live")]
        Live
    }
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<BlockReason>))]
    public enum BlockReason
    {
        [EnumMember(Value = "other")]
        Other = 0,

        [EnumMember(Value = "harassment")]
        Harassment,

        [EnumMember(Value = "spam")]
        Spam
    }
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<BlockContext>))]
    public enum BlockContext
    {
        [EnumMember(Value = "chat")]
        Chat,

        [EnumMember(Value = "whisper")]
        Whisper
    }
}

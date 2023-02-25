using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum BlockContext
    {
        [EnumMember(Value = "chat")]
        Chat,

        [EnumMember(Value = "whisper")]
        Whisper
    }
}

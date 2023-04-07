using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum BlockContext
    {
        [EnumMember(Value = "chat")]
        Chat,

        [EnumMember(Value = "whisper")]
        Whisper
    }
}

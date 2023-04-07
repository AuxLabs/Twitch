using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum TokenType
    {
        None = 0,

        [EnumMember(Value = "Bearer")]
        Bearer
    }
}

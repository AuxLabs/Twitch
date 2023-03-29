using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum TokenType
    {
        None = 0,

        [EnumMember(Value = "Bearer")]
        Bearer
    }
}

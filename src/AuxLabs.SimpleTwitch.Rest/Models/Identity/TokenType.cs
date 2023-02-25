using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum TokenType
    {
        None = 0,

        [EnumMember(Value = "Bearer")]
        Bearer
    }
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<TokenType>))]
    public enum TokenType
    {
        None = 0,

        [EnumMember(Value = "Bearer")]
        Bearer
    }
}

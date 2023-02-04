using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [Flags, JsonConverter(typeof(EnumMemberConverter<EmoteTheme>))]
    public enum EmoteTheme
    {
        [EnumMember(Value = "dark")]
        Dark = 0,

        [EnumMember(Value = "light")]
        Light = 1
    }
}

using AuxLabs.SimpleTwitch.Rest;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch
{
    [Flags, JsonConverter(typeof(EnumMemberConverter<EmoteFormat>))]
    public enum EmoteFormat
    {
        [EnumMember(Value = "static")]
        Static = 0,

        [EnumMember(Value = "animated")]
        Animated = 1
    }
}

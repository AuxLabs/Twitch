using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum EmoteFormat
    {
        [EnumMember(Value = "static")]
        Static = 0,
        [EnumMember(Value = "animated")]
        Animated = 1
    }
}

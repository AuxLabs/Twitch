using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum EmoteTheme
    {
        [EnumMember(Value = "dark")]
        Dark = 0,

        [EnumMember(Value = "light")]
        Light = 1
    }
}

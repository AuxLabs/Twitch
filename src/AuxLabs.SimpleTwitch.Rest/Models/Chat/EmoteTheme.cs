using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum EmoteTheme
    {
        [EnumMember(Value = "dark")]
        Dark = 0,

        [EnumMember(Value = "light")]
        Light = 1
    }
}

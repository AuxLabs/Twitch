using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum ExtensionType
    {
        Unknown = 0,

        [EnumMember(Value = "component")]
        Component,
        [EnumMember(Value = "mobile")]
        Mobile,
        [EnumMember(Value = "overlay")]
        Overlay,
        [EnumMember(Value = "panel")]
        Panel
    }
}

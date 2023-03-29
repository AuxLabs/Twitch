using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum EmoteScale
    {
        /// <summary> A small version (28px x 28px) is available. </summary>
        [EnumMember(Value = "1.0")]
        Small = 1,

        /// <summary> A medium version (56px x 56px) is available. </summary>
        [EnumMember(Value = "2.0")]
        Medium = 2,

        /// <summary> A large version (112px x 112px) is available. </summary>
        [EnumMember(Value = "3.0")]
        Large = 3
    }
}

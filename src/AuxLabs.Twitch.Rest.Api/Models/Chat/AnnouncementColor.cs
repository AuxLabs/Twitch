using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum AnnouncementColor
    {
        [EnumMember(Value = "primary")]
        Primary = 0,

        [EnumMember(Value = "blue")]
        Blue,
        [EnumMember(Value = "green")]
        Green,
        [EnumMember(Value = "orange")]
        Orange,
        [EnumMember(Value = "purple")]
        Purple
    }
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<AnnouncementColor>))]
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

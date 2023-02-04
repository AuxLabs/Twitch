using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<ChatColor>))]
    public enum ChatColor
    {
        None = 0,

        [EnumMember(Value = "blue")]
        Blue,
        [EnumMember(Value = "blue_violet")]
        BlueViolet,
        [EnumMember(Value = "cadet_blue")]
        CadetBlue,
        [EnumMember(Value = "chocolate")]
        Chocolate,
        [EnumMember(Value = "coral")]
        Coral,
        [EnumMember(Value = "dodger_blue")]
        DodgerBlue,
        [EnumMember(Value = "firebrick")]
        Firebrick,
        [EnumMember(Value = "golden_rod")]
        GoldenRod,
        [EnumMember(Value = "green")]
        Green,
        [EnumMember(Value = "hot_pink")]
        HotPink,
        [EnumMember(Value = "orange_red")]
        OrangeRed,
        [EnumMember(Value = "red")]
        Red,
        [EnumMember(Value = "sea_green")]
        SeaGreen,
        [EnumMember(Value = "spring_green")]
        SpringGreen,
        [EnumMember(Value = "yellow_green")]
        YellowGreen
    }
}

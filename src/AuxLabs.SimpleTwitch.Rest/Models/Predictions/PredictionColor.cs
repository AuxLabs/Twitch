using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<PredictionColor>))]
    public enum PredictionColor
    {
        [EnumMember(Value = "BLUE")]
        Blue = 0,
        [EnumMember(Value = "PINK")]
        Pink
    }
}

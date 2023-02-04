using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<CheermoteType>))]
    public enum CheermoteType
    {
        None = 0,

        [EnumMember(Value = "global_first_party")]
        GlobalFirstParty,

        [EnumMember(Value = "global_third_party")]
        GlobalThirdParty,

        [EnumMember(Value = "channel_custom")]
        ChannelCustom,

        [EnumMember(Value = "display_only")]
        DisplayOnly,

        [EnumMember(Value = "sponsored")]
        Sponsored
    }
}

using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum HypeTrainContributionType
    {
        [EnumMember(Value = "OTHER")]
        Other = 0,
        [EnumMember(Value = "BITS")]
        Bits,
        [EnumMember(Value = "SUBS")]
        Subscriptions
    }
}

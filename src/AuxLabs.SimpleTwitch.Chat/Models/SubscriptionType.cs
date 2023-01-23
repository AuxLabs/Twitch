using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public enum SubscriptionType
    {
        Unknown,

        [EnumMember(Value = "Prime")]
        Prime,
        [EnumMember(Value = "1000")]
        Tier1,
        [EnumMember(Value = "2000")]
        Tier2,
        [EnumMember(Value = "3000")]
        Tier3,
    }
}

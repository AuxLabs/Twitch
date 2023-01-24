using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Chat
{
    public enum UserNoticeType
    {
        Unknown,

        [EnumMember(Value = "announcement")]
        Announcement,

        [EnumMember(Value = "sub")]
        Subscription,
        [EnumMember(Value = "resub")]
        Resubscription,
        [EnumMember(Value = "subgift")]
        SubscriptionGift,
        [EnumMember(Value = "submysterygift")]
        SubscriptionMysteryGift,
        [EnumMember(Value = "giftpaidupgrade")]
        SubscriptionGiftUpgrade,
        [EnumMember(Value = "rewardgift")]
        RewardGift,
        [EnumMember(Value = "anongiftpaidupgrade")]
        SubscriptionGiftUpgradeAnonymous,

        [EnumMember(Value = "raid")]
        Raid,
        [EnumMember(Value = "unraid")]
        Unraid,
        [EnumMember(Value = "ritual")]
        Ritual,
        [EnumMember(Value = "bitsbadgetier")]
        BitsBadgeTier
    }

    public enum RitualType
    {
        Unknown,

        [EnumMember(Value = "new_chatter")]
        NewChatter
    }
}

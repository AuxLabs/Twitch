using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum EmoteType
    {
        None = 0,

        /// <summary> A custom bits tier emote. </summary>
        [EnumMember(Value = "bitstier")]
        BitsTier,

        /// <summary> A custom follower emote. </summary>
        [EnumMember(Value = "follower")]
        Follower,

        /// <summary> A custom subscriber emote. </summary>
        [EnumMember(Value = "subscriptions")]
        Subscription
    }
}

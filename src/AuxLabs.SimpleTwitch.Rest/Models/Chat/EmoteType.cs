using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<EmoteType>))]
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

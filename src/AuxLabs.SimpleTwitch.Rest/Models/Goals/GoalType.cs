using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<GoalType>))]
    public enum GoalType
    {
        None = 0,

        /// <summary> The goal is to increase followers. </summary>
        [EnumMember(Value = "follower")]
        Follower,

        /// <summary> The goal is to increase subscriptions. </summary>
        /// <remarks> This type shows the net increase or decrease in tier points associated with the subscriptions. </remarks>
        [EnumMember(Value = "subscription")]
        Subscription,

        /// <summary> The goal is to increase subscriptions. </summary>
        /// <remarks> This type shows the net increase or decrease in the number of subscriptions. </remarks>
        [EnumMember(Value = "subscription_count")]
        SusbcriptionCount,

        /// <summary> The goal is to increase subscriptions. </summary>
        /// <remarks> This type shows only the net increase in tier points associated with the subscriptions. </remarks>
        [EnumMember(Value = "new_subscription")]
        NewSubscription,

        /// <summary> The goal is to increase subscriptions. </summary>
        /// <remarks> This type shows only the net increase in the number of subscriptions. </remarks>
        [EnumMember(Value = "new_subscription_count")]
        NewSubscriptionCount
    }
}

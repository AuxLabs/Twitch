using AuxLabs.SimpleTwitch.Rest;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubPayload : EventSubPayload<object> { }
    public class EventSubPayload<TEvent>
    {
        [JsonPropertyName("challenge")]
        public string Challenge { get; set; }

        [JsonPropertyName("subscription")]
        public EventSubscription Subscription { get; set; }

        [JsonPropertyName("event")]
        public TEvent Event { get; set; }

        [JsonIgnore]
        public static Dictionary<EventSubType, Type> EventTypeSelector => new Dictionary<EventSubType, Type>()
        {
            [EventSubType.ChannelUpdate] = typeof(ChannelUpdateEventArgs),
            [EventSubType.ChannelFollow] = typeof(ChannelFollowEventArgs),
            [EventSubType.ChannelSubscribe] = typeof(SubscriptionEventArgs),
            [EventSubType.ChannelSubscriptionEnd] = typeof(SubscriptionEventArgs),
            [EventSubType.ChannelSubscriptionGift] = typeof(SubscriptionGiftedEventArgs),
            [EventSubType.ChannelSubscriptionMessage] = typeof(SubscriptionMessageEventArgs),
            [EventSubType.ChannelCheer] = typeof(CheerEventArgs),
            [EventSubType.ChannelRaid] = typeof(RaidEventArgs),

            [EventSubType.ChannelBan] = typeof(BanEventArgs),
            [EventSubType.ChannelUnban] = typeof(UnbanEventArgs),
            [EventSubType.ChannelModeratorAdd] = typeof(ModeratorEventArgs),
            [EventSubType.ChannelModeratorRemove] = typeof(ModeratorEventArgs),

            [EventSubType.ChannelPointsRewardAdd] = typeof(RewardEventArgs),
            [EventSubType.ChannelPointsRewardUpdate] = typeof(RewardEventArgs),
            [EventSubType.ChannelPointsRewardRemove] = typeof(RewardEventArgs),
            [EventSubType.ChannelPointsRedemptionAdd] = typeof(RedemptionEventArgs),
            [EventSubType.ChannelPointsRedemptionUpdate] = typeof(RedemptionEventArgs),

            [EventSubType.ChannelPollStart] = typeof(PollEventArgs),
            [EventSubType.ChannelPollProgress] = typeof(PollEventArgs),
            [EventSubType.ChannelPollEnd] = typeof(PollEndedEventArgs),

            [EventSubType.ChannelPredictionStart] = typeof(PredictionStartedEventArgs),
            [EventSubType.ChannelPredictionProgress] = typeof(PredictionProgressEventArgs),
            [EventSubType.ChannelPredictionLock] = typeof(PredictionLockedEventArgs),
            [EventSubType.ChannelPredictionEnd] = typeof(PredictionEndedEventArgs),

            [EventSubType.CharityDonation] = typeof(DonationEventArgs),
            [EventSubType.CharityCampaignStart] = typeof(CampaignStartedEventArgs),
            [EventSubType.CharityCampaignProgress] = typeof(CampaignProgressEventArgs),
            [EventSubType.CharityCampaignStop] = typeof(CampaignEndedEventArgs),

            [EventSubType.DropEntitlementGrant] = typeof(EntitlementGrantEventArgs),
            [EventSubType.ExtensionBitsTransactionCreate] = typeof(BitsTransactionEventArgs),

            [EventSubType.GoalStart] = typeof(GoalStartedEventArgs),
            [EventSubType.GoalProgress] = typeof(GoalProgressEventArgs),
            [EventSubType.GoalEnd] = typeof(GoalEndedEventArgs),

            [EventSubType.HypeTrainStart] = typeof(HypeTrainStartedEventArgs),
            [EventSubType.HypeTrainProgress] = typeof(HypeTrainProgressEventArgs),
            [EventSubType.HypeTrainEnd] = typeof(HypeTrainEndedEventArgs),

            [EventSubType.ShieldModeStart] = typeof(ShieldModeStartedEventArgs),
            [EventSubType.ShieldModeEnd] = typeof(ShieldModeEndedEventArgs),

            [EventSubType.ShoutoutCreate] = typeof(ShoutoutCreatedEventArgs),
            [EventSubType.ShoutoutReceived] = typeof(ShoutoutReceivedEventArgs),

            [EventSubType.StreamOnline] = typeof(BroadcastStartedEventArgs),
            [EventSubType.StreamOffline] = typeof(BroadcastEndedEventArgs),

            [EventSubType.UserAuthorizationGrant] = typeof(AuthorizationGrantedEventArgs),
            [EventSubType.UserAuthorizationRevoke] = typeof(AuthorizationRevokedEventArgs),

            [EventSubType.UserUpdate] = typeof(UserUpdatedEventArgs)
        };
    }
}

using AuxLabs.Twitch.Rest;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class EventSubPayload : EventSubPayload<object> { }
    public class EventSubPayload<TEvent>
    {
        [JsonInclude, JsonPropertyName("challenge")]
        public string Challenge { get; internal set; }

        [JsonInclude, JsonPropertyName("subscription")]
        public EventSubscription Subscription { get; internal set; }

        [JsonInclude, JsonPropertyName("event")]
        public TEvent Event { get; internal set; }

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

            [EventSubType.ChannelPredictionStart] = typeof(PredictionEventArgs),
            [EventSubType.ChannelPredictionProgress] = typeof(PredictionEventArgs),
            [EventSubType.ChannelPredictionLock] = typeof(PredictionEventArgs),
            [EventSubType.ChannelPredictionEnd] = typeof(PredictionEndedEventArgs),

            [EventSubType.CharityDonation] = typeof(DonationEventArgs),
            [EventSubType.CharityCampaignStart] = typeof(CampaignStartedEventArgs),
            [EventSubType.CharityCampaignProgress] = typeof(CampaignProgressEventArgs),
            [EventSubType.CharityCampaignStop] = typeof(CampaignEndedEventArgs),

            [EventSubType.DropEntitlementGrant] = typeof(EntitlementGrantEventArgs),
            [EventSubType.ExtensionBitsTransactionCreate] = typeof(BitsTransactionEventArgs),

            [EventSubType.GoalStart] = typeof(Goal),
            [EventSubType.GoalProgress] = typeof(Goal),
            [EventSubType.GoalEnd] = typeof(GoalEndedEventArgs),

            [EventSubType.HypeTrainStart] = typeof(HypeTrainEventArgs),
            [EventSubType.HypeTrainProgress] = typeof(HypeTrainEventArgs),
            [EventSubType.HypeTrainEnd] = typeof(HypeTrainEndedEventArgs),

            [EventSubType.ShieldModeStart] = typeof(ShieldModeStartedEventArgs),
            [EventSubType.ShieldModeEnd] = typeof(ShieldModeEventArgs),

            [EventSubType.ShoutoutCreate] = typeof(ShoutoutCreatedEventArgs),
            [EventSubType.ShoutoutReceived] = typeof(ShoutoutReceivedEventArgs),

            [EventSubType.StreamOnline] = typeof(BroadcastStartedEventArgs),
            [EventSubType.StreamOffline] = typeof(BroadcastEndedEventArgs),

            [EventSubType.UserAuthorizationGrant] = typeof(AuthorizationEventArgs),
            [EventSubType.UserAuthorizationRevoke] = typeof(AuthorizationEventArgs),

            [EventSubType.UserUpdate] = typeof(UserUpdatedEventArgs)
        };
    }
}

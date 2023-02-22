﻿using AuxLabs.SimpleTwitch.Rest;
using AuxLabs.SimpleTwitch.WebSockets;
using System;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class TwitchEventSubApiClient : BaseSocketClient<EventSubFrame>
    {
        #region Events

        /// <summary> Triggered when a session is created after connection. </summary>
        public event Action<Session> SessionCreated;
        /// <summary> Triggered when the server requests a reconnect. </summary>
        public event Action<Session> Reconnect;
        /// <summary> Triggered when the user no longer exists or they revoked the authorization token that the subscription relied on. </summary>
        public event Action<EventSubscription> Revocation;

        /// <summary> A broadcaster updates their channel properties e.g., category, title, mature flag, broadcast, or language. </summary>
        public event Action<ChannelUpdateEventArgs, EventSubscription> ChannelUpdated;
        /// <summary> A specified channel receives a follow. </summary>
        public event Action<Follower, EventSubscription> ChannelFollow;
        /// <summary> A notification when a specified channel receives a subscriber. This does not include resubscribes. </summary>
        public event Action<SubscriptionEventArgs, EventSubscription> Subscription;
        /// <summary> A notification when a subscription to the specified channel ends. </summary>
        public event Action<SubscriptionEndedEventArgs, EventSubscription> SubscriptionEnd;
        /// <summary> A notification when a viewer gives a gift subscription to one or more users in the specified channel. </summary>
        public event Action<SubscriptionGiftedEventArgs, EventSubscription> SubscriptionGifted;
        /// <summary> A notification when a user sends a resubscription chat message in a specific channel. </summary>
        public event Action<SubscriptionMessageEventArgs, EventSubscription> SubscriptionMessage;
        /// <summary> A user cheers on the specified channel. </summary>
        public event Action<CheerEventArgs, EventSubscription> BitsCheered;
        /// <summary> A broadcaster raids another broadcaster’s channel. </summary>
        public event Action<RaidEventArgs, EventSubscription> ChannelRaided;

        /// <summary> A viewer is banned from the specified channel. </summary>
        public event Action<BanEventArgs, EventSubscription> UserBanned;
        /// <summary> A viewer is unbanned from the specified channel. </summary>
        public event Action<UnbanEventArgs, EventSubscription> UserUnbanned;
        /// <summary> Moderator privileges were added to a user on a specified channel. </summary>
        public event Action<ModeratorAddedEventArgs, EventSubscription> ModeratorAdded;
        /// <summary> Moderator privileges were removed from a user on a specified channel. </summary>
        public event Action<ModeratorRemovedEventArgs, EventSubscription> ModeratorRemoved;

        /// <summary> A custom channel points reward has been created for the specified channel. </summary>
        public event Action<RewardAddedEventArgs, EventSubscription> RewardAdded;
        /// <summary> A custom channel points reward has been updated for the specified channel. </summary>
        public event Action<RewardUpdatedEvent, EventSubscription> RewardUpdated;
        /// <summary> A custom channel points reward has been removed from the specified channel. </summary>
        public event Action<RewardRemovedEventArgs, EventSubscription> RewardRemoved;
        /// <summary> A viewer has redeemed a custom channel points reward on the specified channel. </summary>
        public event Action<RedemptionAddedEvent, EventSubscription> RedemptionAdded;
        /// <summary> A redemption of a channel points custom reward has been updated for the specified channel. </summary>
        public event Action<RedemptionUpdatedEvent, EventSubscription> RedemptionUpdated;

        /// <summary> A poll started on a specified channel. </summary>
        public event Action<PollEventArgs, EventSubscription> PollStarted;
        /// <summary> Users respond to a poll on a specified channel. </summary>
        public event Action<PollEventArgs, EventSubscription> PollProgress;
        /// <summary> A poll ended on a specified channel. </summary>
        public event Action<PollEndedEventArgs, EventSubscription> PollEnded;

        /// <summary> A Prediction started on a specified channel. </summary>
        public event Action<PredictionStartedEventArgs, EventSubscription> PredictionStarted;
        /// <summary> Users participated in a Prediction on a specified channel. </summary>
        public event Action<PredictionProgressEventArgs, EventSubscription> PredictionProgress;
        /// <summary> A Prediction was locked on a specified channel. </summary>
        public event Action<PredictionLockedEventArgs, EventSubscription> PredictionLocked;
        /// <summary> A Prediction ended on a specified channel. </summary>
        public event Action<PredictionEndedEventArgs, EventSubscription> PredictionEnded;

        /// <summary> Sends an event notification when a user donates to the broadcaster’s charity campaign. </summary>
        public event Action<DonationEventArgs, EventSubscription> CharityDonation;
        /// <summary> Sends an event notification when the broadcaster starts a charity campaign. </summary>
        public event Action<CampaignStartedEventArgs, EventSubscription> CharityCampaignStarted;
        /// <summary> Sends an event notification when progress is made towards the campaign’s goal or when the broadcaster changes the fundraising goal. </summary>
        public event Action<CampaignProgressEventArgs, EventSubscription> CharityCampaignProgress;
        /// <summary> Sends an event notification when the broadcaster stops a charity campaign. </summary>
        public event Action<CampaignEndedEventArgs, EventSubscription> CharityCampaignStopped;

        /// <summary> An entitlement for a Drop is granted to a user. </summary>
        public event Action<EntitlementGrantEventArgs, EventSubscription> DropEntitlementGranted;
        /// <summary> A Bits transaction occurred for a specified Twitch Extension. </summary>
        public event Action<BitsTransactionEventArgs, EventSubscription> BitsTransactionCreated;

        /// <summary> Get notified when a broadcaster begins a goal. </summary>
        public event Action<GoalStartedEventArgs, EventSubscription> GoalStarted;
        /// <summary> Get notified when progress (either positive or negative) is made towards a broadcaster’s goal. </summary>
        public event Action<GoalProgressEventArgs, EventSubscription> GoalProgress;
        /// <summary> Get notified when a broadcaster ends a goal. </summary>
        public event Action<GoalEndedEventArgs, EventSubscription> GoalEnded;

        /// <summary> A Hype Train begins on the specified channel. </summary>
        public event Action<HypeTrainStartedEventArgs, EventSubscription> HypeTrainStarted;
        /// <summary> A Hype Train makes progress on the specified channel. </summary>
        public event Action<HypeTrainProgressEventArgs, EventSubscription> HypeTrainProgress;
        /// <summary> A Hype Train ends on the specified channel. </summary>
        public event Action<HypeTrainEndedEventArgs, EventSubscription> HypeTrainEnded;

        /// <summary> Sends a notification when the broadcaster activates Shield Mode. </summary>
        public event Action<ShieldModeStartedEventArgs, EventSubscription> ShieldModeStarted;
        /// <summary> Sends a notification when the broadcaster deactivates Shield Mode. </summary>
        public event Action<ShieldModeEndedEventArgs, EventSubscription> ShieldModeEnded;

        /// <summary> Sends a notification when the specified broadcaster sends a Shoutout. </summary>
        public event Action<ShoutoutCreatedEventArgs, EventSubscription> ShoutoutCreated;
        /// <summary> Sends a notification when the specified broadcaster receives a Shoutout. </summary>
        public event Action<ShoutoutReceivedEventArgs, EventSubscription> ShoutoutReceived;

        /// <summary> The specified broadcaster starts a stream. </summary>
        public event Action<StreamStartedEventArgs, EventSubscription> StreamStarted;
        /// <summary> The specified broadcaster stops a stream. </summary>
        public event Action<StreamEndedEventArgs, EventSubscription> StreamEnded;

        /// <summary> A user’s authorization has been granted to your client id. </summary>
        public event Action<AuthorizationGrantedEventArgs, EventSubscription> AuthorizationGranted;
        /// <summary> A user’s authorization has been revoked for your client id. </summary>
        public event Action<AuthorizationRevokedEventArgs, EventSubscription> AuthorizationRevoked;

        /// <summary> A user has updated their account. </summary>
        public event Action<UserUpdatedEventArgs, EventSubscription> UserUpdated;

        #endregion

        // config variables
        public readonly bool ThrowOnUnknownEvent;

        protected override ISerializer<EventSubFrame> Serializer { get; }

        private string _url;

        public Session Session { get; protected set; }

        public TwitchEventSubApiClient(TwitchEventSubConfig config = null)
            : this(TwitchConstants.EventSubUrl, config) { }
        public TwitchEventSubApiClient(string url, TwitchEventSubConfig config = null) : base(-1, true)
        {
            config ??= new TwitchEventSubConfig();

            _url = url;
            ThrowOnUnknownEvent = config.ThrowOnUnknownEvent;

            Serializer = config.Serializer ?? new JsonSerializer<EventSubFrame>();
        }

        public override void Run() => Run(_url);
        public override Task RunAsync() => RunAsync(_url);

        protected override void HandleEvent(EventSubFrame frame, TaskCompletionSource<bool> readySignal)
        {
            switch (frame.Metadata.Type)
            {
                case MessageType.Welcome:
                    Session = frame.Payload.Session;
                    SessionCreated?.Invoke(Session);
                    break;

                case MessageType.KeepAlive:     // Send to log event, we don't need to do anything else here
                    break;

                case MessageType.Reconnect:
                    Session = frame.Payload.Session;
                    Reconnect?.Invoke(Session);
                    break;

                case MessageType.Revocation:
                    Revocation?.Invoke(frame.Payload.Subscription);
                    break;

                case MessageType.Notification:

                    switch (frame.Payload.Event)
                    {
                        case ChannelUpdateEventArgs args:
                            ChannelUpdated?.Invoke(args, frame.Payload.Subscription);
                            break;

                        // Insert the load of subscription event types here

                        default:
                            OnUnknownEventReceived(frame);
                            if (ThrowOnUnknownEvent)
                                throw new TwitchException($"An unhandled notification event of type `{frame.Payload.Subscription.TypeRaw}` was received");
                            break;
                    }
                    break;

                default:
                    OnUnknownEventReceived(frame);
                    if (ThrowOnUnknownEvent)
                        throw new TwitchException($"An unhandled event of type `{frame.Metadata.TypeRaw}` was received");
                    break;
            }
        }
    }
}

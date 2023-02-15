using AuxLabs.SimpleTwitch.Rest;
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
        public event Action<Session> Reconnect;

        public event Action<ChannelUpdateEventArgs, EventSubcription> ChannelUpdated;
        public event Action<Follower, EventSubcription> ChannelFollow;
        public event Action<SubscriptionEventArgs, EventSubcription> Subscription;
        public event Action<SubscriptionEndedEventArgs, EventSubcription> SubscriptionEnd;
        public event Action<SubscriptionGiftedEventArgs, EventSubcription> SubscriptionGifted;
        public event Action<SubscriptionMessageEventArgs, EventSubcription> SubscriptionMessage;
        public event Action<CheerEventArgs, EventSubcription> BitsCheered;
        public event Action<RaidEventArgs, EventSubcription> ChannelRaided;

        public event Action<BanEventArgs, EventSubcription> UserBanned;
        public event Action<UnbanEventArgs, EventSubcription> UserUnbanned;
        public event Action<ModeratorAddedEventArgs, EventSubcription> ModeratorAdded;
        public event Action<ModeratorRemovedEventArgs, EventSubcription> ModeratorRemoved;

        public event Action<RewardAddedEventArgs, EventSubcription> RewardAdded;
        public event Action<RewardUpdatedEvent, EventSubcription> RewardUpdated;
        public event Action<RewardRemovedEventArgs, EventSubcription> RewardRemoved;
        public event Action<RedemptionAddedEvent, EventSubcription> RedemptionAdded;
        public event Action<RedemptionUpdatedEvent, EventSubcription> RedemptionUpdated;

        public event Action<PollStartedEventArgs, EventSubcription> PollStarted;
        public event Action<PollProgressEventArgs, EventSubcription> PollProgress;
        public event Action<PollEndedEventArgs, EventSubcription> PollEnded;

        public event Action<PredictionStartedEventArgs, EventSubcription> PredictionStarted;
        public event Action<PredictionProgressEventArgs, EventSubcription> PredictionProgress;
        public event Action<PredictionLockedEventArgs, EventSubcription> PredictionLocked;
        public event Action<PredictionEndedEventArgs, EventSubcription> PredictionEnded;

        public event Action<DonationEventArgs, EventSubcription> CharityDonation;
        public event Action<CampaignStartedEventArgs, EventSubcription> CharityCampaignStarted;
        public event Action<CampaignProgressEventArgs, EventSubcription> CharityCampaignProgress;
        public event Action<CampaignEndedEventArgs, EventSubcription> CharityCampaignStopped;

        public event Action<EntitlementGrantEventArgs, EventSubcription> DropEntitlementGranted;
        public event Action<BitsTransactionEventArgs, EventSubcription> BitsTransactionCreated;

        public event Action<GoalStartedEventArgs, EventSubcription> GoalStarted;
        public event Action<GoalProgressEventArgs, EventSubcription> GoalProgress;
        public event Action<GoalEndedEventArgs, EventSubcription> GoalEnded;

        public event Action<HypeTrainStartedEventArgs, EventSubcription> HypeTrainStarted;
        public event Action<HypeTrainProgressEventArgs, EventSubcription> HypeTrainProgress;
        public event Action<HypeTrainEndedEventArgs, EventSubcription> HypeTrainEnded;

        public event Action<ShieldModeStartedEventArgs, EventSubcription> ShieldModeStarted;
        public event Action<ShieldModeEndedEventArgs, EventSubcription> ShieldModeEnded;

        public event Action<ShoutoutCreatedEventArgs, EventSubcription> ShoutoutCreated;
        public event Action<ShoutoutReceivedEventArgs, EventSubcription> ShoutoutReceived;

        public event Action<StreamStartedEventArgs, EventSubcription> StreamStarted;
        public event Action<StreamEndedEventArgs, EventSubcription> StreamEnded;

        public event Action<AuthorizationGrantedEventArgs, EventSubcription> AuthorizationGranted;
        public event Action<AuthorizationRevokedEventArgs, EventSubcription> AuthorizationRevoked;

        public event Action<UserUpdatedEventArgs, EventSubcription> UserUpdated;

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

        protected override void SendHeartbeat()
        {
            throw new NotImplementedException();
        }

        protected override void SendHeartbeatAck()
        {
            throw new NotImplementedException();
        }

        protected override void HandleEvent(EventSubFrame payload, TaskCompletionSource<bool> readySignal)
        {
            switch (payload.Metadata.Type)
            {
                case MessageType.Welcome:
                    Session = payload.Payload.Session;
                    SessionCreated?.Invoke(Session);
                    break;

                case MessageType.KeepAlive:     // Send to log event, we don't need to do anything with this event
                    break;

                case MessageType.Reconnect:
                    Session = payload.Payload.Session;
                    Reconnect?.Invoke(Session);
                    break;

                case MessageType.Revocation:
                    break;

                case MessageType.Notification:

                    switch (payload.Payload.Event)
                    {
                        case ChannelUpdateEventArgs args:
                            ChannelUpdated?.Invoke(args, payload.Payload.Subscription);
                            break;

                        // Insert the load of subscription event types here

                        default:
                            OnUnknownEventReceived(payload);
                            if (ThrowOnUnknownEvent)
                                throw new TwitchException($"An unhandled notification event of type `{payload.Payload.Subscription.TypeRaw}` was received");
                            break;
                    }
                    break;

                default:
                    OnUnknownEventReceived(payload);
                    if (ThrowOnUnknownEvent)
                        throw new TwitchException($"An unhandled event of type `{payload.Metadata.TypeRaw}` was received");
                    break;
            }
        }
    }
}

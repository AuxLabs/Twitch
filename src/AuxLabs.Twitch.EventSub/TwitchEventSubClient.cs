using AuxLabs.Twitch.EventSub.Api;
using AuxLabs.Twitch.EventSub.Entities;
using AuxLabs.Twitch.EventSub.Models;
using AuxLabs.Twitch.Rest;
using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.EventSub
{
    public partial class TwitchEventSubClient : IDisposable
    {
        private bool _disposed = false;

        protected TwitchEventSubApiClient EventSub { get; }
        public TwitchRestClient Rest { get; }

        public AppIdentity Identity => Rest.Identity;
        public Session Session => EventSub.Session;

        public TwitchEventSubClient(TwitchEventSubConfig config = null)
            : this(TwitchConstants.EventSubUrl, config) { }
        public TwitchEventSubClient(string url, TwitchEventSubConfig config = null)
        {
            Rest = new TwitchRestClient(config.RestConfig ??= new TwitchRestConfig());
            EventSub = new TwitchEventSubApiClient(config);

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            EventSub.Connected += () => _connectedEvent.InvokeAsync().ConfigureAwait(false);
            EventSub.Reconnect += (s) => _reconnectEvent.InvokeAsync(s).ConfigureAwait(false);
            EventSub.Disconnected += (ex) => _disconnectedEvent.InvokeAsync(ex).ConfigureAwait(false);

            EventSub.SessionCreated += (s) => _sessionCreatedEvent.InvokeAsync(s).ConfigureAwait(false);
            EventSub.Revocation += (s) => _revocationEvent.InvokeAsync(RestEventSubscription.Create(Rest, s)).ConfigureAwait(false);
            EventSub.NotificationReceived += (p) => _notificationReceivedEvent.InvokeAsync(p).ConfigureAwait(false);

            EventSub.ChannelUpdated += (args, sub) => Task.Delay(0);
            EventSub.ChannelFollow += (args, sub) => Task.Delay(0);
            EventSub.ChannelRaided += (args, sub) => Task.Delay(0);
            EventSub.Subscription += (args, sub) => Task.Delay(0);
            EventSub.SubscriptionEnded += (args, sub) => Task.Delay(0);
            EventSub.SubscriptionGifted += (args, sub) => Task.Delay(0);
            EventSub.SubscriptionMessage += (args, sub) => Task.Delay(0);
            EventSub.BitsCheered += (args, sub) => Task.Delay(0);

            EventSub.UserBanned += (args, sub) => _userBannedEvent.InvokeAsync(BanEventArgs.Create(this, args), sub).ConfigureAwait(false);
            EventSub.UserUnbanned += (args, sub) => Task.Delay(0);
            EventSub.ModeratorAdded += (args, sub) => Task.Delay(0);
            EventSub.ModeratorRemoved += (args, sub) => Task.Delay(0);

            EventSub.RewardAdded += (args, sub) => Task.Delay(0);
            EventSub.RewardUpdated += (args, sub) => Task.Delay(0);
            EventSub.RewardRemoved += (args, sub) => Task.Delay(0);
            EventSub.RedemptionAdded += (args, sub) => Task.Delay(0);
            EventSub.RedemptionUpdated += (args, sub) => Task.Delay(0);

            EventSub.PollStarted += (args, sub) => Task.Delay(0);
            EventSub.PollProgress += (args, sub) => Task.Delay(0);
            EventSub.PollEnded += (args, sub) => Task.Delay(0);

            EventSub.PredictionStarted += (args, sub) => Task.Delay(0);
            EventSub.PredictionProgress += (args, sub) => Task.Delay(0);
            EventSub.PredictionLocked += (args, sub) => Task.Delay(0);
            EventSub.PredictionEnded += (args, sub) => Task.Delay(0);

            EventSub.CharityDonation += (args, sub) => Task.Delay(0);
            EventSub.CharityCampaignStarted += (args, sub) => Task.Delay(0);
            EventSub.CharityCampaignProgress += (args, sub) => Task.Delay(0);
            EventSub.CharityCampaignEnded += (args, sub) => Task.Delay(0);

            EventSub.DropEntitlementGranted += (args, sub) => Task.Delay(0);
            EventSub.BitsTransactionCreated += (args, sub) => Task.Delay(0);

            EventSub.GoalStarted += (args, sub) => Task.Delay(0);
            EventSub.GoalProgress += (args, sub) => Task.Delay(0);
            EventSub.GoalEnded += (args, sub) => Task.Delay(0);

            EventSub.HypeTrainStarted += (args, sub) => Task.Delay(0);
            EventSub.HypeTrainProgress += (args, sub) => Task.Delay(0);
            EventSub.HypeTrainEnded += (args, sub) => Task.Delay(0);

            EventSub.ShieldModeEnabled += (args, sub) => Task.Delay(0);
            EventSub.ShieldModeDisabled += (args, sub) => Task.Delay(0);

            EventSub.ShoutoutCreated += (args, sub) => Task.Delay(0);
            EventSub.ShoutoutReceived += (args, sub) => Task.Delay(0);

            EventSub.BroadcastStarted += (args, sub) => _broadcastStartedEvent.InvokeAsync(EventSubBroadcast.Create(this, args), sub).ConfigureAwait(false);
            EventSub.BroadcastEnded += (args, sub) => _broadcastEndedEvent.InvokeAsync(EventSubSimpleUser.Create(this, args), sub).ConfigureAwait(false);

            EventSub.UserUpdated += (args, sub) => _userUpdatedEvent.InvokeAsync(EventSubUser.Create(this, args), sub).ConfigureAwait(false);
            EventSub.AuthorizationGranted += (args, sub) => Task.Delay(0);
            EventSub.AuthorizationRevoked += (args, sub) => Task.Delay(0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    Rest.Dispose();

                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        #region Identity

        /// <inheritdoc/>
        public Task<AccessTokenInfo> ValidateAsync(string token)
            => Rest.ValidateAsync(token);

        #endregion
        #region Event Subscriptions

        public Task<IReadOnlyCollection<RestEventSubscription>> GetSubscriptionsAsync(string userId = null, EventSubStatus? status = null, EventSubType? type = null)
            => Rest.GetEventSubscriptionsAsync(userId, status, type);
        public Task DeleteSubscriptionAsync(string subscriptionId)
            => Rest.DeleteEventSubscriptionAsync(subscriptionId);

        #endregion
        #region Broadcasts

        public Task<RestEventSubscription> SubscribeAsync(BroadcastEndedSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(BroadcastStartedSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Channels

        public Task<RestEventSubscription> SubscribeAsync(ChannelUpdateSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(CheerSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(FollowSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(RaidSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(ShoutoutCreateSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(ShoutoutReceiveSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Charity

        public Task<RestEventSubscription> SubscribeAsync(CampaignProgressSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(CampaignStartSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(CampaignStopSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(DonationSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Drops

        public Task<RestEventSubscription> SubscribeAsync(EntitlementGrantSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Extensions

        public Task<RestEventSubscription> SubscribeAsync(BitsTransactionSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Goals

        public Task<RestEventSubscription> SubscribeAsync(GoalEndSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(GoalProgressSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(GoalStartSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Hypetrains

        public Task<RestEventSubscription> SubscribeAsync(HypetrainEndSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(HypetrainProgressSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(HypetrainStartSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Moderation

        public Task<RestEventSubscription> SubscribeAsync(BanSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(ModeratorAddSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(ModeratorRemoveSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(ShieldModeEndSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(ShieldModeStartSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(UnbanSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Polls

        public Task<RestEventSubscription> SubscribeAsync(PollEndSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(PollProgressSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(PollStartSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Predictions

        public Task<RestEventSubscription> SubscribeAsync(PredictionEndSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(PredictionLockSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(PredictionProgressSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(PredictionStartSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Rewards

        public Task<RestEventSubscription> SubscribeAsync(RedemptionAddSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(RedemptionUpdateSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(RewardAddSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(RewardRemoveSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(RewardUpdateSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Subscriptions

        public Task<RestEventSubscription> SubscribeAsync(SubscribeSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(SubscriptionEndSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(SubscriptionGiftSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(SubscriptionMessageSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
        #region Users

        public Task<RestEventSubscription> SubscribeAsync(AuthorizationGrantedSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(AuthorizationRevokedSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);
        public Task<RestEventSubscription> SubscribeAsync(UserUpdateSubscription args)
            => Rest.CreateEventSubscriptionAsync(args);

        #endregion
    }
}

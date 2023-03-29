using AuxLabs.Twitch.EventSub.Api;
using AuxLabs.Twitch.EventSub.Models;
using AuxLabs.Twitch.Rest;
using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

            EventSub.Connected += () => _connectedEvent.InvokeAsync().ConfigureAwait(false);
            EventSub.Reconnect += (s) => _reconnectEvent.InvokeAsync(s).ConfigureAwait(false);
            EventSub.Disconnected += (ex) => _disconnectedEvent.InvokeAsync(ex).ConfigureAwait(false);
            EventSub.PayloadReceived += (p, e) => HandleEventAsync(p).ConfigureAwait(false);
            EventSub.SessionCreated += (s) => _sessionCreatedEvent.InvokeAsync(s).ConfigureAwait(false);
            EventSub.Revocation += (s) => _revocationEvent.InvokeAsync(RestEventSubscription.Create(Rest, s)).ConfigureAwait(false);
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

        private async Task HandleEventAsync(EventSubFrame frame)
        {
            if (frame.Metadata.Type != MessageType.Notification)
                return;

            var eventType = EventSubPayload.EventTypeSelector.SingleOrDefault(x => x.Key == frame.Payload.Subscription.Type).Value;
            var eventData = JsonSerializer.Deserialize((JsonElement)frame.Payload.Event, eventType);

            switch (eventData)
            {
                case Models.BanEventArgs args:
                    await _userBannedEvent.InvokeAsync(BanEventArgs.Create(this, args));
                    break;

                default:
                    break;
            }
        }
    }
}

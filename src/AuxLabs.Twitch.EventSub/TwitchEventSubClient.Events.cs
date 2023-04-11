using AuxLabs.Twitch.EventSub.Api;
using AuxLabs.Twitch.EventSub.Entities;
using AuxLabs.Twitch.EventSub.Models;
using System;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.EventSub
{
    public partial class TwitchEventSubClient
    {
        #region Connection

        /// <summary> Triggered when the socket connection is established </summary>
        public event Func<Task> Connected
        {
            add { _connectedEvent.Add(value); }
            remove { _connectedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _connectedEvent = new AsyncEvent<Func<Task>>();

        /// <summary> Triggered when the socket connection is closed </summary>
        public event Func<Exception, Task> Disconnected
        {
            add { _disconnectedEvent.Add(value); }
            remove { _disconnectedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Exception, Task>> _disconnectedEvent = new AsyncEvent<Func<Exception, Task>>();

        /// <summary> Triggered when the server tells the client to reconnect </summary>
        public event Func<Session, Task> Reconnect
        {
            add { _reconnectEvent.Add(value); }
            remove { _reconnectEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Session, Task>> _reconnectEvent = new AsyncEvent<Func<Session, Task>>();

        /// <summary> Triggered when a notification payload is received. </summary>
        public event Func<EventSubFrame, Task> NotificationReceived
        {
            add { _notificationReceivedEvent.Add(value); }
            remove { _notificationReceivedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<EventSubFrame, Task>> _notificationReceivedEvent = new AsyncEvent<Func<EventSubFrame, Task>>();

        #endregion
        #region Status

        /// <summary>  </summary>
        public event Func<Session, Task> SessionCreated
        {
            add { _sessionCreatedEvent.Add(value); }
            remove { _sessionCreatedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Session, Task>> _sessionCreatedEvent = new AsyncEvent<Func<Session, Task>>();

        /// <summary>  </summary>
        public event Func<EventSubEventSubscription, Task> Revocation
        {
            add { _revocationEvent.Add(value); }
            remove { _revocationEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<EventSubEventSubscription, Task>> _revocationEvent = new AsyncEvent<Func<EventSubEventSubscription, Task>>();

        #endregion
        #region Channel

        // ChannelUpdated
        // ChannelFollow
        // ChannelRaided
        // Subscription
        // SubscriptionEnded
        // SubscriptionGifted
        // SubscriptionMessage
        // BitsCheered

        #endregion
        #region Moderation

        /// <summary>  </summary>
        public event Func<BanEventArgs, EventSubEventSubscription, Task> UserBanned
        {
            add { _userBannedEvent.Add(value); }
            remove { _userBannedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<BanEventArgs, EventSubEventSubscription, Task>> _userBannedEvent = new AsyncEvent<Func<BanEventArgs, EventSubEventSubscription, Task>>();

        // UserUnbanned
        // ModeratorAdded
        // ModeratorRemoved

        #endregion
        #region Rewards

        // RewardAdded
        // RewardUpdated
        // RewardRemoved
        // RedemptionAdded
        // RedemptionUpdated

        #endregion
        #region Polls

        // PollStarted
        // PollProgress
        // PollEnded

        #endregion
        #region Predictions

        // PredictionStarted
        // PredictionProgress
        // PredictionLocked
        // PredictionEnded

        #endregion
        #region Charity

        // CharityDonation
        // CharityCampaignStarted
        // CharityCampaignProgress
        // CharityCampaignEnded

        #endregion
        #region Drops/Extensions

        // DropEntitlementGranted
        // BitsTransactionCreated

        #endregion
        #region Goals

        // GoalStarted
        // GoalProgress
        // GoalEnded

        #endregion
        #region HypeTrains

        // HypeTrainStarted
        // HypeTrainProgress
        // HypeTrainEnded

        #endregion
        #region ShieldMode

        // ShieldModeEnabled
        // ShieldModeDisabled

        #endregion
        #region Broadcasts

        /// <summary>  </summary>
        public event Func<EventSubBroadcast, EventSubEventSubscription, Task> BroadcastStarted
        {
            add { _broadcastStartedEvent.Add(value); }
            remove { _broadcastStartedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<EventSubBroadcast, EventSubEventSubscription, Task>> _broadcastStartedEvent = new AsyncEvent<Func<EventSubBroadcast, EventSubEventSubscription, Task>>();

        /// <summary>  </summary>
        public event Func<EventSubSimpleUser, EventSubEventSubscription, Task> BroadcastEnded
        {
            add { _broadcastEndedEvent.Add(value); }
            remove { _broadcastEndedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<EventSubSimpleUser, EventSubEventSubscription, Task>> _broadcastEndedEvent = new AsyncEvent<Func<EventSubSimpleUser, EventSubEventSubscription, Task>>();

        #endregion
        #region User

        /// <summary>  </summary>
        public event Func<EventSubUser, EventSubEventSubscription, Task> UserUpdated
        {
            add { _userUpdatedEvent.Add(value); }
            remove { _userUpdatedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<EventSubUser, EventSubEventSubscription, Task>> _userUpdatedEvent = new AsyncEvent<Func<EventSubUser, EventSubEventSubscription, Task>>();

        // AuthorizationGranted
        // AuthorizationRevoked

        #endregion
    }
}

using AuxLabs.Twitch.Chat;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Chat
{
    public partial class TwitchChatClient
    {
        /// <summary> Triggered when the socket connection is established </summary>
        public event Func<Task> Connected
        {
            add { _connectedEvent.Add(value); }
            remove { _connectedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _connectedEvent = new AsyncEvent<Func<Task>>();

        /// <summary> Triggered when the socket connection is established </summary>
        public event Func<ChatSelfUser, Task> LoggedIn
        {
            add { _loggedInEvent.Add(value); }
            remove { _loggedInEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatSelfUser, Task>> _loggedInEvent = new AsyncEvent<Func<ChatSelfUser, Task>>();

        /// <summary> Triggered when the socket connection is closed </summary>
        public event Func<Exception, Task> Disconnected
        {
            add { _disconnectedEvent.Add(value); }
            remove { _disconnectedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Exception, Task>> _disconnectedEvent = new AsyncEvent<Func<Exception, Task>>();

        /// <summary> Triggered when the server tells the client to reconnect </summary>
        public event Func<Task> Reconnect
        {
            add { _reconnectEvent.Add(value); }
            remove { _reconnectEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _reconnectEvent = new AsyncEvent<Func<Task>>();

        /// <summary> Triggered when an unknown event is received </summary>
        public event Func<IrcPayload, Task> UnhandledCommand
        {
            add { _unhandledCommandEvent.Add(value); }
            remove { _unhandledCommandEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<IrcPayload, Task>> _unhandledCommandEvent = new AsyncEvent<Func<IrcPayload, Task>>();
        
        /// <summary> Triggered when the entire chat is cleared in a channel. </summary>
        /// <remarks> Provides an object that represents the channel and a collection of messages that were deleted, if cached. </remarks>
        public event Func<ChatChannel, IReadOnlyCollection<ChatMessage>, Task> ChatCleared
        {
            add { _chatClearedEvent.Add(value); }
            remove { _chatClearedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatChannel, IReadOnlyCollection<ChatMessage>, Task>> _chatClearedEvent = new AsyncEvent<Func<ChatChannel, IReadOnlyCollection<ChatMessage>, Task>>();

        /// <summary> Triggered when a user is banned in a channel. </summary>
        /// <remarks> Provides objects that represent the channel, the banned user, and the amount of time they were banned. The ban is permanent if time is null. </remarks>
        public event Func<ChatChannel, ChatSimpleUser, TimeSpan?, Task> UserBanned
        {
            add { _userBannedEvent.Add(value); }
            remove { _userBannedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatChannel, ChatSimpleUser, TimeSpan?, Task>> _userBannedEvent = new AsyncEvent<Func<ChatChannel, ChatSimpleUser, TimeSpan?, Task>>();

        /// <summary> Triggered when a message is deleted in a channel. </summary>
        /// <remarks> Provides an object that represents the deleted message. </remarks>
        public event Func<ChatSimpleMessage, Task> MessageDeleted
        {
            add { _messageDeletedEvent.Add(value); }
            remove { _messageDeletedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatSimpleMessage, Task>> _messageDeletedEvent = new AsyncEvent<Func<ChatSimpleMessage, Task>>();

        /// <summary> Triggered when the currently authorized user joins a channel. </summary>
        /// <remarks> Provides a string that represents the channel's name. </remarks>
        public event Func<string, Task> ChannelJoined
        {
            add { _channelJoinedEvent.Add(value); }
            remove { _channelJoinedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<string, Task>> _channelJoinedEvent = new AsyncEvent<Func<string, Task>>();

        /// <summary> Triggered when any user joins a channel. </summary>
        /// <remarks> Provides an object that represents the channel, and a string that represents the user's name. </remarks>
        public event Func<ChatSimpleChannel, string, Task> UserJoinedChannel
        {
            add { _userJoinedChannelEvent.Add(value); }
            remove { _userJoinedChannelEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatSimpleChannel, string, Task>> _userJoinedChannelEvent = new AsyncEvent<Func<ChatSimpleChannel, string, Task>>();

        /// <summary> Triggered when the currently authorized user leaves a channel. </summary>
        /// <remarks> Provides an object that represents the channel, if cached. </remarks>
        public event Func<ChatSimpleChannel, Task> ChannelLeft
        {
            add { _channelLeftEvent.Add(value); }
            remove { _channelLeftEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatSimpleChannel, Task>> _channelLeftEvent = new AsyncEvent<Func<ChatSimpleChannel, Task>>();

        /// <summary> Triggered when any user leaves a channel. </summary>
        /// <remarks> Provides an object that represents the channel, and a string that represents the user's name. </remarks>
        public event Func<ChatSimpleChannel, string, Task> UserLeftChannel
        {   
            add { _userLeftChannelEvent.Add(value); }
            remove { _userLeftChannelEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatSimpleChannel, string, Task>> _userLeftChannelEvent = new AsyncEvent<Func<ChatSimpleChannel, string, Task>>();

        /// <summary>  </summary>
        public event Func<Task> WhisperReceived
        {
            add { _whisperReceivedEvent.Add(value); }
            remove { _whisperReceivedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _whisperReceivedEvent = new AsyncEvent<Func<Task>>();

        /// <summary> Triggered when a message is received in a channel </summary>
        /// <remarks> Provides an object that represents the message. </remarks>
        public event Func<ChatMessage, Task> MessageReceived
        {
            add { _messageReceivedEvent.Add(value); }
            remove { _messageReceivedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatMessage, Task>> _messageReceivedEvent = new AsyncEvent<Func<ChatMessage, Task>>();

        /// <summary> Triggered when the state of a channel is updated. </summary>
        /// <remarks> Provides the channel's state before the change, if cached, and the state after. </remarks>
        public event Func<ChatChannel, ChatChannel, Task> ChannelStateUpdated
        {
            add { _channelStateUpdated.Add(value); }
            remove { _channelStateUpdated.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatChannel, ChatChannel, Task>> _channelStateUpdated = new AsyncEvent<Func<ChatChannel, ChatChannel, Task>>();

        /// <summary> Triggered when the current user's state is updated. </summary>
        /// <remarks> Provides the user's state before the change, if cached, and the state after. </remarks>
        public event Func<ChatChannelSelfUser, ChatChannelSelfUser, string, Task> UserStateUpdated
        {
            add { _userStateUpdatedEvent.Add(value); }
            remove { _userStateUpdatedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<ChatChannelSelfUser, ChatChannelSelfUser, string, Task>> _userStateUpdatedEvent = new AsyncEvent<Func<ChatChannelSelfUser, ChatChannelSelfUser, string, Task>>();


        // User Notice Events


        /// <summary>  </summary>
        public event Func<Task> ChannelBitsTierUnlocked
        {
            add { _bitsTierUnlockedEvent.Add(value); }
            remove { _bitsTierUnlockedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _bitsTierUnlockedEvent = new AsyncEvent<Func<Task>>();

        /// <summary>  </summary>
        public event Func<Task> ChannelRaided
        {
            add { _channelRaidedEvent.Add(value); }
            remove { _channelRaidedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _channelRaidedEvent = new AsyncEvent<Func<Task>>();

        /// <summary>  </summary>
        public event Func<Task> ChannelRaidEnded
        {
            add { _channelRaidEndedEvent.Add(value); }
            remove { _channelRaidEndedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _channelRaidEndedEvent = new AsyncEvent<Func<Task>>();

        /// <summary>  </summary>
        public event Func<Task> ChannelRitual
        {
            add { _channelRitualEvent.Add(value); }
            remove { _channelRitualEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _channelRitualEvent = new AsyncEvent<Func<Task>>();

        /// <summary>  </summary>
        public event Func<Task> SubscriptionGifted
        {
            add { _subscriptionGiftedEvent.Add(value); }
            remove { _subscriptionGiftedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _subscriptionGiftedEvent = new AsyncEvent<Func<Task>>();

        /// <summary>  </summary>
        public event Func<Task> SubscriptionGiftUpgraded
        {
            add { _subscriptionGiftUpgradedEvent.Add(value); }
            remove { _subscriptionGiftUpgradedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _subscriptionGiftUpgradedEvent = new AsyncEvent<Func<Task>>();

        /// <summary>  </summary>
        public event Func<Task> Subscription
        {
            add { _subscriptionEvent.Add(value); }
            remove { _subscriptionEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<Task>> _subscriptionEvent = new AsyncEvent<Func<Task>>();
    }
}

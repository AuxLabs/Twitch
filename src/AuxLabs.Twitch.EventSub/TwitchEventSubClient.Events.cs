using AuxLabs.Twitch.Rest;
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
        public event Func<RestEventSubscription, Task> Revocation
        {
            add { _revocationEvent.Add(value); }
            remove { _revocationEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<RestEventSubscription, Task>> _revocationEvent = new AsyncEvent<Func<RestEventSubscription, Task>>();

        #endregion
        #region Moderation

        /// <summary>  </summary>
        public event Func<BanEventArgs2, Task> UserBanned
        {
            add { _userBannedEvent.Add(value); }
            remove { _userBannedEvent.Remove(value); }
        }
        internal readonly AsyncEvent<Func<BanEventArgs2, Task>> _userBannedEvent = new AsyncEvent<Func<BanEventArgs2, Task>>();


        #endregion
    }
}

using System;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class BroadcastEndedSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = Array.Empty<string>();

        public BroadcastEndedSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public BroadcastEndedSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.StreamOffline;
        }
    }
}

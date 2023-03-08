using System;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class BroadcastStartedSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = Array.Empty<string>();

        public BroadcastStartedSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public BroadcastStartedSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.StreamOnline;
        }
    }
}

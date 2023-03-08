namespace AuxLabs.SimpleTwitch.Rest
{
    public class SubscriptionMessageSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:subscriptions" };

        public SubscriptionMessageSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public SubscriptionMessageSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelSubscriptionMessage;
        }
    }
}

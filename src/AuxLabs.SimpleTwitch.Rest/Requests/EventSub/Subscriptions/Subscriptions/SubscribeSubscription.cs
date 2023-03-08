namespace AuxLabs.SimpleTwitch.Rest
{
    public class SubscribeSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:subscriptions" };

        public SubscribeSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public SubscribeSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelSubscribe;
        }
    }
}

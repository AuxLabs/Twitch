namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheerSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "bits:read" };

        public CheerSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public CheerSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelCheer;
        }
    }
}

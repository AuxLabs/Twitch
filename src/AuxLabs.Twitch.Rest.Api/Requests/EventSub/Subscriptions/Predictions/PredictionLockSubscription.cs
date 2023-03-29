namespace AuxLabs.Twitch.Rest
{
    public class PredictionLockSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:predictions", "channel:manage:predictions" };

        public PredictionLockSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public PredictionLockSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPredictionLock;
        }
    }
}

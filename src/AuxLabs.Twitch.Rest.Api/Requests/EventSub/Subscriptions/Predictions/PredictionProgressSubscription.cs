namespace AuxLabs.Twitch.Rest
{
    public class PredictionProgressSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:predictions", "channel:manage:predictions" };

        public PredictionProgressSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public PredictionProgressSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPredictionProgress;
        }
    }
}

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PredictionEndSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:predictions", "channel:manage:predictions" };

        public PredictionEndSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public PredictionEndSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPredictionEnd;
        }
    }
}

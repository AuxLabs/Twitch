namespace AuxLabs.Twitch.Rest.Requests
{
    public class SubscriptionEndSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:subscriptions" };

        public SubscriptionEndSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public SubscriptionEndSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelSubscriptionEnd;
        }
    }
}

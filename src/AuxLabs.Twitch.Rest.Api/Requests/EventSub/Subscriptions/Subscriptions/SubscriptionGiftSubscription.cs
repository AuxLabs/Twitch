namespace AuxLabs.Twitch.Rest.Requests
{
    public class SubscriptionGiftSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:subscriptions" };

        public SubscriptionGiftSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public SubscriptionGiftSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelSubscriptionGift;
        }
    }
}

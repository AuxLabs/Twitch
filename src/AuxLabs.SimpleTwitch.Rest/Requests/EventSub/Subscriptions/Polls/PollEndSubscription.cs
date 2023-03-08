namespace AuxLabs.SimpleTwitch.Rest
{
    public class PollEndSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:polls", "channel:manage:polls" };

        public PollEndSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public PollEndSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPollEnd;
        }
    }
}

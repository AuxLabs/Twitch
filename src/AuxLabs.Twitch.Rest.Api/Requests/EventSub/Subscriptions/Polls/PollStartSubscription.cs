namespace AuxLabs.Twitch.Rest
{
    public class PollStartSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:polls", "channel:manage:polls" };

        public PollStartSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public PollStartSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPollStart;
        }
    }
}

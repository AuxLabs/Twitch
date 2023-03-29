namespace AuxLabs.Twitch.Rest
{
    public class PollProgressSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:polls", "channel:manage:polls" };

        public PollProgressSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public PollProgressSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPollProgress;
        }
    }
}

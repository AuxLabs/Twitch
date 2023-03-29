namespace AuxLabs.Twitch.Rest.Requests
{
    public class UnbanSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:moderate" };

        public UnbanSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public UnbanSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelUnban;
        }
    }
}

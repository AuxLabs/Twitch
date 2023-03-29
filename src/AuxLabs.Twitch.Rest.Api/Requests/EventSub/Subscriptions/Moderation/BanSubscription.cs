namespace AuxLabs.Twitch.Rest.Requests
{
    public class BanSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:moderate" };

        public BanSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public BanSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelBan;
        }
    }
}

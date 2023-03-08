namespace AuxLabs.SimpleTwitch.Rest
{
    public class CampaignProgressSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:charity" };

        public CampaignProgressSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public CampaignProgressSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.CharityCampaignProgress;
        }
    }
}

namespace AuxLabs.Twitch.Rest
{
    public class CampaignStopSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:charity" };

        public CampaignStopSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public CampaignStopSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.CharityCampaignStop;
        }
    }
}

namespace AuxLabs.Twitch.Rest.Requests
{
    public class CampaignStartSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:charity" };

        public CampaignStartSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public CampaignStartSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.CharityCampaignStart;
        }
    }
}

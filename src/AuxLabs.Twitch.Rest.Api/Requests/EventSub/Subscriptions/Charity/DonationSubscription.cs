namespace AuxLabs.Twitch.Rest.Requests
{
    public class DonationSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:charity" };

        public DonationSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public DonationSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.CharityDonation;
        }
    }
}

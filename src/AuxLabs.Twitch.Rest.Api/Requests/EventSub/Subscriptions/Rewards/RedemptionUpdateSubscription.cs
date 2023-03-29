namespace AuxLabs.Twitch.Rest.Requests
{
    public class RedemptionUpdateSubscription : RewardSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:redemptions", "channel:manage:redemptions" };

        public RedemptionUpdateSubscription(string channelId, string rewardId, string sessionId)
            : base(channelId, rewardId, sessionId) => SetProperties();
        public RedemptionUpdateSubscription(string channelId, string rewardId, string callback, string secret)
            : base(channelId, rewardId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPointsRedemptionUpdate;
        }
    }
}

namespace AuxLabs.Twitch.Rest.Requests
{
    public class RewardAddSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:redemptions", "channel:manage:redemptions" };

        public RewardAddSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public RewardAddSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPointsRewardAdd;
        }
    }
}

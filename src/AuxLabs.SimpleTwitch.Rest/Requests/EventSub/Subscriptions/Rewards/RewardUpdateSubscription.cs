﻿namespace AuxLabs.SimpleTwitch.Rest
{
    public class RewardUpdateSubscription : RewardSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:redemptions", "channel:manage:redemptions" };

        public RewardUpdateSubscription(string channelId, string rewardId, string sessionId)
            : base(channelId, rewardId, sessionId) => SetProperties();
        public RewardUpdateSubscription(string channelId, string rewardId, string callback, string secret)
            : base(channelId, rewardId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPointsRewardUpdate;
        }
    }
}
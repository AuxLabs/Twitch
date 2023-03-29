﻿namespace AuxLabs.Twitch.Rest.Requests
{
    public class PredictionStartSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:predictions", "channel:manage:predictions" };

        public PredictionStartSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public PredictionStartSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelPredictionStart;
        }
    }
}
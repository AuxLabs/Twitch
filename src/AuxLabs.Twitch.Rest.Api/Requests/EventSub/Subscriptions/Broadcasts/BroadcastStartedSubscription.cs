namespace AuxLabs.Twitch.Rest
{
    public class BroadcastStartedSubscription : PostEventSubscriptionBody<BroadcasterCondition>
    {
        public BroadcastStartedSubscription(string channelId, string sessionId)
            : base(sessionId) => SetProperties(channelId);
        public BroadcastStartedSubscription(string channelId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(channelId);

        private void SetProperties(string channelId)
        {
            Type = EventSubType.StreamOnline;
            Version = "1";
            Condition = channelId;
        }
    }
}

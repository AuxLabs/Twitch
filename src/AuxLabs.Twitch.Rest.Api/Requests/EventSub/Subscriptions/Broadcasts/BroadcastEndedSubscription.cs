namespace AuxLabs.Twitch.Rest
{
    public class BroadcastEndedSubscription : PostEventSubscriptionBody<BroadcasterCondition>
    {
        public BroadcastEndedSubscription(string channelId, string sessionId)
            : base(sessionId) => SetProperties(channelId);
        public BroadcastEndedSubscription(string channelId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(channelId);

        private void SetProperties(string channelId)
        {
            Type = EventSubType.StreamOffline;
            Version = "1";
            Condition = channelId;
        }
    }
}

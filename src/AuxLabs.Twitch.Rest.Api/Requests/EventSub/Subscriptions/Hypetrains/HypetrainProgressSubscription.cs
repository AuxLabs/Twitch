namespace AuxLabs.Twitch.Rest
{
    public class HypetrainProgressSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:hype_train" };

        public HypetrainProgressSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public HypetrainProgressSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.HypeTrainProgress;
        }
    }
}

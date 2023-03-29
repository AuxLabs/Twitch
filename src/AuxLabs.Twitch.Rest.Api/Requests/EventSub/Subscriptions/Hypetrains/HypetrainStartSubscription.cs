namespace AuxLabs.Twitch.Rest.Requests
{
    public class HypetrainStartSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:hype_train" };

        public HypetrainStartSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public HypetrainStartSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.HypeTrainStart;
        }
    }
}

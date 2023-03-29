namespace AuxLabs.Twitch.Rest.Requests
{
    public class HypetrainEndSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:hype_train" };

        public HypetrainEndSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public HypetrainEndSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.HypeTrainEnd;
        }
    }
}

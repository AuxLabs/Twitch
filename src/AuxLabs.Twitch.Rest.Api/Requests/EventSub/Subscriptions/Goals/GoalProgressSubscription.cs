namespace AuxLabs.Twitch.Rest.Requests
{
    public class GoalProgressSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:goals" };

        public GoalProgressSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public GoalProgressSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.GoalProgress;
        }
    }
}

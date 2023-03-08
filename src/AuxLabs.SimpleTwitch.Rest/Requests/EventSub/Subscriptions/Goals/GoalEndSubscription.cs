namespace AuxLabs.SimpleTwitch.Rest
{
    public class GoalEndSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:goals" };

        public GoalEndSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public GoalEndSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.GoalEnd;
        }
    }
}

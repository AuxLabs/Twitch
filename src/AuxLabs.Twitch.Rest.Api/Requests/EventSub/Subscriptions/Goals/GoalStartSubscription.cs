namespace AuxLabs.Twitch.Rest.Requests
{
    public class GoalStartSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "channel:read:goals" };

        public GoalStartSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public GoalStartSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.GoalStart;
        }
    }
}

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ShoutoutReceiveSubscription : ModeratorSubscriptionBase
    {
        public override string[] Scopes { get; } = { "moderator:read:shoutouts", "moderator:manage:shoutouts" };

        public ShoutoutReceiveSubscription(string channelId, string moderatorId, string sessionId)
            : base(channelId, moderatorId, sessionId) => SetProperties();
        public ShoutoutReceiveSubscription(string channelId, string moderatorId, string callback, string secret)
            : base(channelId, moderatorId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ShoutoutReceived;
        }
    }
}

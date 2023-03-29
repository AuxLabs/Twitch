namespace AuxLabs.Twitch.Rest
{
    public class ShoutoutCreateSubscription : ModeratorSubscriptionBase
    {
        public override string[] Scopes { get; } = { "moderator:read:shoutouts", "moderator:manage:shoutouts" };

        public ShoutoutCreateSubscription(string channelId, string moderatorId, string sessionId)
            : base(channelId, moderatorId, sessionId) => SetProperties();
        public ShoutoutCreateSubscription(string channelId, string moderatorId, string callback, string secret)
            : base(channelId, moderatorId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ShoutoutCreate;
        }
    }
}

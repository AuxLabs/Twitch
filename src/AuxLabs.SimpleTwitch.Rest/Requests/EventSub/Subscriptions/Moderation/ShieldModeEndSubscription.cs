namespace AuxLabs.SimpleTwitch.Rest
{
    public class ShieldModeEndSubscription : ModeratorSubscriptionBase
    {
        public override string[] Scopes { get; } = { "moderator:read:shield_mode", "moderator:manage:shield_mode" };

        public ShieldModeEndSubscription(string channelId, string moderatorId, string sessionId)
            : base(channelId, moderatorId, sessionId) => SetProperties();
        public ShieldModeEndSubscription(string channelId, string moderatorId, string callback, string secret)
            : base(channelId, moderatorId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ShieldModeEnd;
        }
    }
}

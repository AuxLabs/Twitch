namespace AuxLabs.Twitch.Rest
{
    public class ShieldModeStartSubscription : ModeratorSubscriptionBase
    {
        public override string[] Scopes { get; } = { "moderator:read:shield_mode", "moderator:manage:shield_mode" };

        public ShieldModeStartSubscription(string channelId, string moderatorId, string sessionId)
            : base(channelId, moderatorId, sessionId) => SetProperties();
        public ShieldModeStartSubscription(string channelId, string moderatorId, string callback, string secret)
            : base(channelId, moderatorId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ShieldModeStart;
        }
    }
}

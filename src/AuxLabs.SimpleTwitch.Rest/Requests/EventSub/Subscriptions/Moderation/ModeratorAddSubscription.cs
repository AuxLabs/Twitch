namespace AuxLabs.SimpleTwitch.Rest
{
    public class ModeratorAddSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "moderation:read" };

        public ModeratorAddSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public ModeratorAddSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelModeratorAdd;
        }
    }
}

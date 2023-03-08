namespace AuxLabs.SimpleTwitch.Rest
{
    public class ModeratorRemoveSubscription : BroadcasterSubscriptionBase
    {
        public override string[] Scopes { get; } = { "moderation:read" };

        public ModeratorRemoveSubscription(string channelId, string sessionId)
            : base(channelId, sessionId) => SetProperties();
        public ModeratorRemoveSubscription(string channelId, string callback, string secret)
            : base(channelId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelModeratorRemove;
        }
    }
}

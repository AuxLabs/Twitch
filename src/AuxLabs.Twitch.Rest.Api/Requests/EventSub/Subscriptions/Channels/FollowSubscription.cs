namespace AuxLabs.Twitch.Rest.Requests
{
    public class FollowSubscription : ModeratorSubscriptionBase
    {
        public override string[] Scopes { get; } = { "moderator:read:followers" };

        public FollowSubscription(string channelId, string moderatorId, string sessionId)
            : base(channelId, moderatorId, sessionId) => SetProperties();
        public FollowSubscription(string channelId, string moderatorId, string callback, string secret)
            : base(channelId, moderatorId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.ChannelFollow;
        }
    }
}

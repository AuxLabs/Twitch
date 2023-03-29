namespace AuxLabs.Twitch.Rest
{
    public class RaidSubscription : PostEventSubscriptionBody<RaidCondition>
    {
        public RaidSubscription(RaidConditionType type, string channelId, string sessionId)
            : base(sessionId) => SetProperties(type, channelId);
        public RaidSubscription(RaidConditionType type, string channelId, string callback, string secret)
            : base(callback, secret) => SetProperties(type, channelId);

        private void SetProperties(RaidConditionType type, string channelId)
        {
            Type = EventSubType.ChannelRaid;
            Version = "1";
            Condition = (type, channelId);
        }
    }
}

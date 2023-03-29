using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class ChannelUpdateSubscription : PostEventSubscriptionBody<BroadcasterCondition>
    {
        public ChannelUpdateSubscription(string channelId, string sessionId)
            : base(sessionId) => SetProperties(channelId);
        public ChannelUpdateSubscription(string channelId, string callback, string secret)
            : base(callback, secret) => SetProperties(channelId);

        private void SetProperties(string channelId)
        {
            Type = EventSubType.ChannelUpdate;
            Version = "1";
            Condition = channelId;
        }
    }
}

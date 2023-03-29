using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public abstract class BroadcasterSubscriptionBase : PostEventSubscriptionBody<BroadcasterCondition>, IScopedRequest
    {
        public abstract string[] Scopes { get; }

        public BroadcasterSubscriptionBase(string channelId, string sessionId)
            : base(sessionId) => SetProperties(channelId);
        public BroadcasterSubscriptionBase(string channelId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(channelId);

        private void SetProperties(string channelId)
        {
            Version = "1";
            Condition = channelId;
        }

        public void Validate(IEnumerable<string> scopes)
        {
            if (Transport.Method == TransportMethod.WebSocket)
                Require.Scopes(scopes, Scopes);
            Validate();
        }
    }
}

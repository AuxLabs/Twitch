using AuxLabs.Twitch.Rest.Models;
using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public abstract class RewardSubscriptionBase : PostEventSubscriptionBody<RewardCondition>, IScopedRequest
    {
        public abstract string[] Scopes { get; }

        public RewardSubscriptionBase(string channelId, string rewardId, string sessionId)
            : base(sessionId) => SetProperties(channelId, rewardId);
        public RewardSubscriptionBase(string channelId, string rewardId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(channelId, rewardId);

        private void SetProperties(string channelId, string rewardId)
        {
            Version = "1";
            Condition = (channelId, rewardId);
        }

        public void Validate(IEnumerable<string> scopes)
        {
            if (Transport.Method == TransportMethod.WebSocket)
                Require.Scopes(scopes, Scopes);
            Validate();
        }
    }
}
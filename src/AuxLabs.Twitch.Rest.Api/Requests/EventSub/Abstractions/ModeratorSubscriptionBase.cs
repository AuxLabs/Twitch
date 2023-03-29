using AuxLabs.Twitch.Rest.Models;
using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public abstract class ModeratorSubscriptionBase : PostEventSubscriptionBody<ModeratorCondition>, IScopedRequest
    {
        public abstract string[] Scopes { get; }

        public ModeratorSubscriptionBase(string channelId, string moderatorId, string sessionId)
            : base(sessionId) => SetProperties(channelId, moderatorId);
        public ModeratorSubscriptionBase(string channelId, string moderatorId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(channelId, moderatorId);

        private void SetProperties(string channelId, string moderatorId)
        {
            Version = "1";
            Condition = (channelId, moderatorId);
        }

        public void Validate(IEnumerable<string> scopes)
        {
            if (Transport.Method == TransportMethod.WebSocket)
                Require.Scopes(scopes, Scopes);
            Validate();
        }
    }
}

using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public abstract class AuthorizationSubscriptionBase : PostEventSubscriptionBody<AuthorizationCondition>, IScopedRequest
    {
        public abstract string[] Scopes { get; }

        public AuthorizationSubscriptionBase(string clientId, string sessionId)
            : base(sessionId) => SetProperties(clientId);
        public AuthorizationSubscriptionBase(string clientId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(clientId);

        private void SetProperties(string clientId)
        {
            Version = "1";
            Condition = clientId;
        }

        public void Validate(IEnumerable<string> scopes)
        {
            if (Transport.Method == TransportMethod.WebSocket)
                Require.Scopes(scopes, Scopes);
            Validate();
        }
    }
}

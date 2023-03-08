using System;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AuthorizationRevokedSubscription : AuthorizationSubscriptionBase
    {
        public override string[] Scopes { get; } = Array.Empty<string>();

        public AuthorizationRevokedSubscription(string clientId, string sessionId)
            : base(clientId, sessionId) => SetProperties();
        public AuthorizationRevokedSubscription(string clientId, string callback, string secret)
            : base(clientId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.UserAuthorizationRevoke;
        }
    }
}

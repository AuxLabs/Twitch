using System;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AuthorizationGrantedSubscription : AuthorizationSubscriptionBase
    {
        public override string[] Scopes { get; } = Array.Empty<string>();

        public AuthorizationGrantedSubscription(string clientId, string sessionId)
            : base(clientId, sessionId) => SetProperties();
        public AuthorizationGrantedSubscription(string clientId, string callback, string secret)
            : base(clientId, callback, secret) => SetProperties();

        private void SetProperties()
        {
            Type = EventSubType.UserAuthorizationGrant;
        }
    }
}

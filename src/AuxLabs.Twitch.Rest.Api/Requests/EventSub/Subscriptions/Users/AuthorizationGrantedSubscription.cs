namespace AuxLabs.Twitch.Rest
{
    public class AuthorizationGrantedSubscription : AuthorizationSubscriptionBase
    {
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

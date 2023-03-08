namespace AuxLabs.SimpleTwitch.Rest
{
    public abstract class AuthorizationSubscriptionBase : PostEventSubscriptionBody<AuthorizationCondition>
    {
        public AuthorizationSubscriptionBase(string clientId, string sessionId)
            : base(sessionId) => SetProperties(clientId);
        public AuthorizationSubscriptionBase(string clientId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(clientId);

        private void SetProperties(string clientId)
        {
            Version = "1";
            Condition = clientId;
        }
    }
}

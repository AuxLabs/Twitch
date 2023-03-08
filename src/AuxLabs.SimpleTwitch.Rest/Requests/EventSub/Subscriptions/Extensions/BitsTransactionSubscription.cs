namespace AuxLabs.SimpleTwitch.Rest
{
    public class BitsTransactionSubscription : PostEventSubscriptionBody<ExtensionCondition>
    {
        public BitsTransactionSubscription(string clientId, string sessionId)
            : base(sessionId) => SetProperties(clientId);
        public BitsTransactionSubscription(string clientId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(clientId);

        private void SetProperties(string clientId)
        {
            Type = EventSubType.ExtensionBitsTransactionCreate;
            Version = "1";
            Condition = clientId;
        }
    }
}

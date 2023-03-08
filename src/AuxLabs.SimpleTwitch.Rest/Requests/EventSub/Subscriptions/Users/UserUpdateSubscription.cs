namespace AuxLabs.SimpleTwitch.Rest
{
    public class UserUpdateSubscription : PostEventSubscriptionBody<UserCondition>
    {
        public UserUpdateSubscription(string userId, string sessionId)
            : base(sessionId) => SetProperties(userId);
        public UserUpdateSubscription(string userId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(userId);

        private void SetProperties(string userId)
        {
            Type = EventSubType.UserUpdate;
            Version = "1";
            Condition = userId;
        }
    }
}

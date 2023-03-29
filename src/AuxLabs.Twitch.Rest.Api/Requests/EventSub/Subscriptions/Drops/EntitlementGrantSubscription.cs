using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class EntitlementGrantSubscription : PostEventSubscriptionBody<DropEntitlementCondition>
    {
        public EntitlementGrantSubscription(string organizationId, string categoryId, string campaignId, string sessionId)
            : base(sessionId) => SetProperties(organizationId, categoryId, campaignId);
        public EntitlementGrantSubscription(string organizationId, string categoryId, string campaignId, string callbackUrl, string secret)
            : base(callbackUrl, secret) => SetProperties(organizationId, categoryId, campaignId);

        private void SetProperties(string organizationId, string categoryId, string campaignId)
        {
            Type = EventSubType.DropEntitlementGrant;
            Version = "1";
            Condition = (organizationId, categoryId, campaignId);
        }
    }
}

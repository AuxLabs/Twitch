using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class DeleteEventSubscriptionArgs : QueryMap
    {
        /// <summary> The ID of the subscription to delete. </summary>
        public string SubscriptionId { get; set; }

        public DeleteEventSubscriptionArgs() { }
        public DeleteEventSubscriptionArgs(string subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }

        public void Validate()
        {
            Require.NotNullOrWhitespace(SubscriptionId, nameof(SubscriptionId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["id"] = SubscriptionId
            };
        }

        public static implicit operator string(DeleteEventSubscriptionArgs value) => value.SubscriptionId;
        public static implicit operator DeleteEventSubscriptionArgs(string v) => new DeleteEventSubscriptionArgs(v);
    }
}

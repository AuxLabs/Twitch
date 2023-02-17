using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetEventSubscriptionsArgs : QueryMap, IPaginated
    {
        /// <summary> Filter subscriptions by its status. </summary>
        public EventSubStatus? Status { get; set; }

        /// <summary> Filter subscriptions by subscription type. </summary>
        public EventSubType? Type { get; set; }

        /// <summary> Filter subscriptions by user ID. </summary>
        public string UserId { get; set; }

        public string After { get; set; }

        public void Validate()
        {
            Require.NotEmptyOrWhitespace(UserId, nameof(UserId));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (Status != null)
                map["status"] = Status.Value.GetStringValue();
            if (Type != null)
                map["type"] = Type.Value.GetStringValue();
            if (UserId != null)
                map["user_id"] = UserId;
            if (After != null)
                map["after"] = After;

            return map;
        }

        int? IPaginated.First { get; set; } = null;
        string IPaginated.Before { get; set; } = null;
    }
}

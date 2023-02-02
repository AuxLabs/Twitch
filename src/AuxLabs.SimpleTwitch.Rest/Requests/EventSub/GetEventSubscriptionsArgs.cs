using AuxLabs.SimpleTwitch.Rest;
using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class GetEventSubscriptionsArgs : QueryMap, IPaginated
    {
        /// <summary> Filter subscriptions by its status. </summary>
        public EventSubStatus? Status { get; set; }

        /// <summary> Filter subscriptions by subscription type. </summary>
        public EventSubType? Type { get; set; }

        /// <summary> Filter subscriptions by user ID. </summary>
        public string UserId { get; set; }

        /// <summary> The cursor used to get the next page of results. </summary>
        public string After { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (Status != null)
                map["status"] = Status.Value.GetEnumMemberValue();
            if (Type != null)
                map["type"] = Type.Value.GetEnumMemberValue();
            if (UserId != null)
                map["user_id"] = UserId;
            if (After != null)
                map["after"] = After;
            return map;
        }

        int? IPaginated.First { get; set; }
    }
}

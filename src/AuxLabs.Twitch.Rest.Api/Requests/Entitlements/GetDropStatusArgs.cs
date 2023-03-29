using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetDropStatusArgs : QueryMap, IPaginatedRequest
    {
        /// <summary> IDs that identify the entitlements to get. </summary>
        /// <remarks> You may specify a maximum of 100 ids. </remarks>
        public string[] EntitlementIds { get; set; }

        /// <summary> The ID of the user that owns the redemption code. </summary>
        public string UserId { get; set; }

        /// <summary> An ID that identifies a game that offered entitlements. </summary>
        public string GameId { get; set; }

        /// <summary> The entitlement’s fulfillment status. </summary>
        public FulfillmentStatus? Status { get; set; }

        /// <inheritdoc/>
        /// <remarks> The minimum page size is 1 entitlement per page and the maximum is 1000. The default is 20. </remarks>
        public int? First { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            Require.HasAtLeast(EntitlementIds, 1, nameof(EntitlementIds));
            Require.HasAtMost(EntitlementIds, 100, nameof(EntitlementIds));
            Require.NotEmptyOrWhitespace(UserId, nameof(UserId));
            Require.NotEmptyOrWhitespace(GameId, nameof(GameId));

            Require.AtMost(First, 1000, nameof(First));
            Require.AtLeast(First, 1, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            if (EntitlementIds?.Length > 0)
            {
                foreach (var item in EntitlementIds)
                    map["id"] = item;
            }
            if (UserId != null) 
                map["user_id"] = UserId;
            if (GameId != null)
                map["game_id"] = GameId;
            if (Status != null)
                map["fulfillment_status"] = Status.Value.GetStringValue();
            if (First != null)
                map["first"] = First.Value.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginatedRequest.Before { get; set; }
    }
}

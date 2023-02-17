using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetDropStatusArgs : QueryMap<string[]>, IPaginated
    {
        /// <summary> IDs that identify the entitlements to get. </summary>
        /// <remarks> You may specify a maximum of 100 ids. </remarks>
        public List<string> EntitlementIds { get; set; }

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

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();

            if (EntitlementIds != null)
                map["id"] = EntitlementIds.ToArray();
            if (UserId != null) 
                map["user_id"] = new[] { UserId };
            if (GameId != null)
                map["game_id"] = new[] { GameId };
            if (Status != null)
                map["fulfillment_status"] = new[] { Status.Value.GetStringValue() };
            if (First != null)
                map["first"] = new[] { First.Value.ToString() };
            if (After != null)
                map["after"] = new[] { After };

            return map;
        }

        string IPaginated.Before { get; set; }
    }
}

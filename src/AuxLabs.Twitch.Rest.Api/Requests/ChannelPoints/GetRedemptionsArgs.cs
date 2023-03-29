using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetRedemptionsArgs : QueryMap, IPaginatedRequest, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:read:redemptions" };

        /// <summary> The ID of the broadcaster that owns the custom reward. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID that identifies the custom reward whose redemptions you want to get. </summary>
        public string RewardId { get; set; }

        /// <summary> The status of the redemptions to return. </summary>
        public RedemptionStatus? Status { get; set; }

        /// <summary> A list of IDs to filter the redemptions by. </summary>
        /// <remarks> You may specify a maximum of 50 IDs. </remarks>
        public string[] RedemptionIds { get; set; }

        /// <summary> The order to sort redemptions by. </summary>
        /// <remarks> Default sort is OLDEST </remarks>
        public RedemptionSort? Sort { get; set; }

        /// <inheritdoc/>
        /// <remarks> The minimum is 1 per page and the maximum is 50. Defaults to 20. </remarks>
        public int? First { get; set; }

        public string After { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(RewardId, nameof(RewardId));
            if (RedemptionIds != null)
                Require.NotNull(Status, nameof(Status), $"Argument cannot be null when {nameof(RedemptionIds)} is specified");

            Require.Exclusive(new object[] { RewardId, RedemptionIds }, new[] { nameof(RewardId), nameof(RedemptionIds) });

            Require.HasAtMost(RedemptionIds, 50, nameof(RedemptionIds));
            Require.AtLeast(First, 1 , nameof(First));
            Require.AtMost(First, 50, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (RewardId != null)
                map["reward_id"] = RewardId;
            if (Status != null)
                map["status"] = Status.Value.GetStringValue();
            if (RedemptionIds?.Length > 0)
            {
                foreach (var item in RedemptionIds)
                    map["id"] = item;
            }
            if (Sort != null)
                map["sort"] = Sort.Value.GetStringValue();
            if (After != null)
                map["after"] = After;
            if (First != null)
                map["first"] = First.Value.ToString();

            return map;
        }

        string IPaginatedRequest.Before { get; set; } = null;
    }
}

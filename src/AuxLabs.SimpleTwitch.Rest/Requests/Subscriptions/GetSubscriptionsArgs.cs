using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetSubscriptionsArgs : QueryMap<string[]>, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "user:read:subscriptions" };

        /// <summary> The broadcaster’s ID. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> Filters the list to include only the specified subscribers. </summary>
        public List<string> UserIds { get; set; }

        /// <inheritdoc/>
        /// <remarks> The minimum page size is 1 and the maximum is 100. Default is 20. </remarks>
        public int? First { get; set; }
        public string Before { get; set; }
        public string After { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotEmptyOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNull(UserIds, nameof(UserIds));
            Require.HasAtLeast(UserIds, 1, nameof(UserIds));
            Require.HasAtMost(UserIds, 100, nameof(UserIds));

            Require.Exclusive(new object[] { Before, After }, new[] { nameof(Before), nameof(After) });
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(Before, nameof(Before));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();

            if (BroadcasterId != null)
                map["broadcaster_id"] = new[] { BroadcasterId };
            if (UserIds != null)
                map["game_id"] = UserIds.ToArray();
            if (First != null)
                map["first"] = new[] { First.Value.ToString() };
            if (Before != null)
                map["before"] = new[] { Before };
            if (After != null)
                map["after"] = new[] { After };

            return map;
        }
    }
}

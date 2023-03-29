using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetBroadcastsArgs : QueryMap, IPaginatedRequest
    {
        /// <summary> A user ID used to filter the list of streams. </summary>
        /// <remarks> You may specify a maximum of 100 IDs </remarks>
        public string[] UserIds { get; set; }

        /// <summary> A user login name used to filter the list of streams. </summary>
        /// <remarks> You may specify a maximum of 100 names </remarks>
        public string[] UserNames { get; set; }

        /// <summary> A game (category) ID used to filter the list of streams. </summary>
        /// <remarks> You may specify a maximum of 100 IDs </remarks>
        public string[] GameIds { get; set; }

        /// <summary> A collection of ISO 639-1 two-letter language codes used to filter the list of streams. </summary>
        /// <remarks> You may specify a maximum of 100 language codes </remarks>
        public string[] Languages { get; set; }

        /// <summary> The type of stream to filter the list of streams by. </summary>
        public BroadcastType? Type { get; set; }

        /// <inheritdoc/>
        /// <remarks> The minimum page size is 1 and the maximum is 100. Default is 20. </remarks>
        public int? First { get; set; }
        public string Before { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            int? userTotal = UserIds?.Length + UserNames?.Length;
            Require.AtMost(userTotal, 100, nameof(userTotal), $"The combined item total of " +
                $"[{nameof(UserIds)}, {nameof(UserNames)}] must be at most 100");

            Require.HasAtLeast(UserIds, 1, nameof(UserIds));
            Require.HasAtMost(UserIds, 100, nameof(UserIds));
            Require.HasAtLeast(UserNames, 1, nameof(UserNames));
            Require.HasAtMost(UserNames, 100, nameof(UserNames));
            Require.HasAtLeast(GameIds, 1, nameof(GameIds));
            Require.HasAtMost(GameIds, 100, nameof(GameIds));
            Require.HasAtLeast(Languages, 1, nameof(Languages));
            Require.HasAtMost(Languages, 100, nameof(Languages));

            Require.Exclusive(new object[] { Before, After }, new[] { nameof(Before), nameof(After) });
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(Before, nameof(Before));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            if (UserIds?.Length > 0)
            {
                foreach (var item in UserIds)
                    map["user_id"] = item;
            }
            if (UserNames?.Length > 0)
            {
                foreach (var item in UserNames)
                    map["user_login"] = item;
            }
            if (GameIds?.Length > 0)
            {
                foreach (var item in GameIds)
                    map["game_id"] = item;
            }
            if (Languages?.Length > 0)
            {
                foreach (var item in Languages)
                    map["language"] = item;
            }
            if (First != null)
                map["first"] = First.Value.ToString();
            if (Before != null)
                map["before"] = Before;
            if (After != null)
                map["after"] = After;

            return map;
        }
    }
}

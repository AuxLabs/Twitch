using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public abstract class GetRolesArgs : QueryMap<string[]>, IPaginated
    {
        /// <summary> The ID of the broadcaster whose list of users you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> A list of user IDs used to filter the results. </summary>
        public List<string> UserIds { get; set; }

        public int? First { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.HasAtMost(UserIds, 100, nameof(UserIds));

            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>
            {
                ["broadcaster_id"] = new[] { BroadcasterId }
            };

            if (UserIds != null)
                map["user_id"] = UserIds.ToArray();
            if (First != null)
                map["first"] = new[] { First.Value.ToString() };
            if (After != null)
                map["after"] = new[] { After };

            return map;
        }

        string IPaginated.Before { get; set; }
    }
}

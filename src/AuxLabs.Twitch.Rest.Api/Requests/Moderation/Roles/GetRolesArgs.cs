using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public abstract class GetRolesArgs : QueryMap, IPaginatedRequest
    {
        /// <summary> The ID of the broadcaster whose list of users you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> A list of user IDs used to filter the results. </summary>
        public string[] UserIds { get; set; }

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

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance)
            {
                ["broadcaster_id"] = BroadcasterId
            };

            if (UserIds?.Length > 0)
            {
                foreach (var item in UserIds)
                    map["user_id"] = item;
            }
            if (First != null)
                map["first"] = First.Value.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginatedRequest.Before { get; set; }
    }
}

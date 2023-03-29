using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch.Rest
{
    public class GetUserColorArgs : QueryMap
    {
        /// <summary> A collection of IDs of the users whose color you want to get. </summary>
        /// <remarks> You may specify a maximum of 100 IDs. </remarks>
        public string[] UserIds { get; set; }

        public GetUserColorArgs() { }
        public GetUserColorArgs(params string[] userIds)
        {
            UserIds = userIds;
        }

        public void Validate()
        {
            Require.NotNull(UserIds, nameof(UserIds));
            Require.HasAtLeast(UserIds, 1, nameof(UserIds));
            Require.HasAtMost(UserIds, 100, nameof(UserIds));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            foreach (var item in UserIds)
                map["user_id"] = item;

            return map;
        }

        public static implicit operator string[](GetUserColorArgs value) => value.UserIds.ToArray();
        public static implicit operator GetUserColorArgs(string[] v) => new GetUserColorArgs(v);
    }
}

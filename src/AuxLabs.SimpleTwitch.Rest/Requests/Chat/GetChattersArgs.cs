using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetChattersArgs : QueryMap, IPaginated, IScoped
    {
        public string[] Scopes { get; } = new[] { "moderator:read:chatters" };

        /// <summary> The ID of the broadcaster whose list of chatters you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster or one of the broadcaster’s moderators. </summary>
        public string ModeratorId { get; set; }

        /// <inheritdoc />
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 20. </remarks>
        public int? First { get; set; }

        /// <inheritdoc />
        public string After { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId,
                ["moderator_id"] = ModeratorId
            };

            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;
            return map;
        }
    }
}

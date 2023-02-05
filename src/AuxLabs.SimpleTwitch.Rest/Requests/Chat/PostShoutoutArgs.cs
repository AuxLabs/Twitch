using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostShoutoutArgs : QueryMap, IScoped
    {
        public string[] Scopes { get; } = { "moderator:manage:shoutouts" };

        /// <summary> The ID of the broadcaster that’s sending the Shoutout. </summary>
        public string FromBroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster that’s receiving the Shoutout. </summary>
        public string ToBroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster or a user that is one of the broadcaster’s moderators. </summary>
        public string ModeratorId { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["from_broadcaster_id"] = FromBroadcasterId,
                ["to_broadcaster_id"] = ToBroadcasterId,
                ["moderator_id"] = ModeratorId
            };
            return map;
        }
    }
}

using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostShoutoutArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "moderator:manage:shoutouts" };

        /// <summary> The ID of the broadcaster that’s sending the Shoutout. </summary>
        public string FromBroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster that’s receiving the Shoutout. </summary>
        public string ToBroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster or a user that is one of the broadcaster’s moderators. </summary>
        public string ModeratorId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(ModeratorId, authedUserId, nameof(ModeratorId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(FromBroadcasterId, nameof(FromBroadcasterId));
            Require.NotNullOrWhitespace(ToBroadcasterId, nameof(ToBroadcasterId));
            Require.NotNullOrWhitespace(ModeratorId, nameof(ModeratorId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["from_broadcaster_id"] = FromBroadcasterId,
                ["to_broadcaster_id"] = ToBroadcasterId,
                ["moderator_id"] = ModeratorId
            };
        }
    }
}

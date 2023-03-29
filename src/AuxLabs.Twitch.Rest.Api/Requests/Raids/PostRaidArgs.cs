using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PostRaidArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:raids" };

        /// <summary> The ID of the broadcaster that’s sending the raiding party. </summary>
        public string FromBroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster to raid. </summary>
        public string ToBroadcasterId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(FromBroadcasterId, authedUserId, nameof(FromBroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(FromBroadcasterId, nameof(FromBroadcasterId));
            Require.NotNullOrWhitespace(ToBroadcasterId, nameof(ToBroadcasterId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["from_broadcaster_id"] = FromBroadcasterId,
                ["to_broadcaster_id"] = ToBroadcasterId
            };
        }
    }
}

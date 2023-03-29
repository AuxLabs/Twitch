using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class PatchChannelArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:broadcast" };

        /// <summary> The ID of the broadcaster whose channel you want to update. </summary>
        public string BroadcasterId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };
        }
    }
}

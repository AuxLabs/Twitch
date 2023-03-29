using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetChannelEditorsArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:read:editors" };

        /// <summary> The ID of the broadcaster that owns the channel. </summary>
        public string BroadcasterId { get; set; }

        public GetChannelEditorsArgs() { }
        public GetChannelEditorsArgs(string broadcasterId)
        {
            BroadcasterId = broadcasterId;
        }

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

        public static implicit operator string(GetChannelEditorsArgs value) => value.BroadcasterId;
        public static implicit operator GetChannelEditorsArgs(string v) => new GetChannelEditorsArgs(v);
    }
}
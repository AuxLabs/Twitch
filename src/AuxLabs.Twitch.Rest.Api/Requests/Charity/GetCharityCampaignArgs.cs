using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetCharityCampaignArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:read:charity" };

        /// <summary> The ID of the broadcaster that’s currently running a charity campaign. </summary>
        public string BroadcasterId { get; set; }

        public GetCharityCampaignArgs() { }
        public GetCharityCampaignArgs(string broadcasterId)
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

        public static implicit operator string(GetCharityCampaignArgs value) => value.BroadcasterId;
        public static implicit operator GetCharityCampaignArgs(string v) => new GetCharityCampaignArgs(v);
    }
}

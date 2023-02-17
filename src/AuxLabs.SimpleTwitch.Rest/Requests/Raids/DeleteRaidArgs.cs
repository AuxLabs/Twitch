using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class DeleteRaidArgs : QueryMap, IScoped
    {
        public string[] Scopes { get; } = { "channel:manage:raids" };

        /// <summary> The ID of the broadcaster that initiated the raid. </summary>
        public string BroadcasterId { get; set; }

        public DeleteRaidArgs() { }
        public DeleteRaidArgs(string broadcasterId)
            => (BroadcasterId) = (broadcasterId);

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

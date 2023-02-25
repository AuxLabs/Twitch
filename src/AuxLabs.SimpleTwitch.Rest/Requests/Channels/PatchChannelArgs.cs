using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PatchChannelArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "channel:manage:broadcast" };

        /// <summary>  </summary>
        public string BroadcasterId { get; set; }

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

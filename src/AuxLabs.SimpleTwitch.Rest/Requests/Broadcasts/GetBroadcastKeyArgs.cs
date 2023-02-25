using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetBroadcastKeyArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "channel:read:stream_key" };

        /// <summary> The ID of the broadcaster that owns the channel. </summary>
        public string BroadcasterId { get; set; }

        public GetBroadcastKeyArgs() { }
        public GetBroadcastKeyArgs(string broadcasterId)
        {
            BroadcasterId = broadcasterId;
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

        public static implicit operator string(GetBroadcastKeyArgs value) => value.BroadcasterId;
        public static implicit operator GetBroadcastKeyArgs(string v) => new GetBroadcastKeyArgs(v);
    }
}
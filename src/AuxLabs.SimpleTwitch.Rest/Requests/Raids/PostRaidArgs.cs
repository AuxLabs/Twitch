using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostRaidArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "channel:manage:raids" };

        /// <summary> The ID of the broadcaster that’s sending the raiding party. </summary>
        public string FromBroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster to raid. </summary>
        public string ToBroadcasterId { get; set; }

        public PostRaidArgs() { }
        public PostRaidArgs(string fromBroadcasterId, string toBroadcasterId)
            => (FromBroadcasterId, ToBroadcasterId) = (fromBroadcasterId, toBroadcasterId);

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

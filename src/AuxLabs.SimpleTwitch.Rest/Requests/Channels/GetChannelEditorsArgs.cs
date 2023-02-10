using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetChannelEditorsArgs : QueryMap, IScoped
    {
        public string[] Scopes { get; } = { "channel:read:editors" };

        /// <summary> The ID of the broadcaster that owns the channel. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        public GetChannelEditorsArgs() { }
        public GetChannelEditorsArgs(string broadcasterId)
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

        public static implicit operator string(GetChannelEditorsArgs value) => value.BroadcasterId;
        public static implicit operator GetChannelEditorsArgs(string v) => new GetChannelEditorsArgs(v);
    }
}
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetCheermotesArgs : QueryMap
    {
        /// <summary> Optional, the ID of the broadcaster that owns the channel. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        public GetCheermotesArgs() { }
        public GetCheermotesArgs(string broadcasterId)
        {
            BroadcasterId = broadcasterId;
        }

        public void Validate()
        {
            Require.NotEmptyOrWhitespace(BroadcasterId, nameof(BroadcasterId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            
            return map;
        }

        public static implicit operator string(GetCheermotesArgs value) => value.BroadcasterId;
        public static implicit operator GetCheermotesArgs(string v) => new GetCheermotesArgs(v);
    }
}

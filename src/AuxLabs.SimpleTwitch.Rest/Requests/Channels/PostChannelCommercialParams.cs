using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class PostChannelCommercialParams : QueryMap<string>, IScoped
    {
        public string[] Scopes { get; } = { "channel:edit:commercial" };

        /// <summary>
        /// Id of the channel requesting a commercial.
        /// </summary>
        public string BroadcasterId { get; set; }

        /// <summary>
        /// Desired length of the commercial in seconds. Optional.
        /// </summary>
        public int? Length { get; set; }

        public PostChannelCommercialParams() { }
        public PostChannelCommercialParams(string broadcasterId, int length)
            => (BroadcasterId, Length) = (broadcasterId, length);

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (Length != null)
                map["length"] = Length.ToString();
            return map;
        }
    }
}

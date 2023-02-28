using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetBadgesArgs : QueryMap
    {
        /// <summary> The ID of the broadcaster whose chat badges you want to get. </summary>
        public string BroadcasterId { get; set; }

        public GetBadgesArgs() { }
        public GetBadgesArgs(string broadcasterId)
        {
            BroadcasterId = broadcasterId;
        }

        public void Validate()
        {
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };
        }

        public static implicit operator string(GetBadgesArgs value) => value.BroadcasterId;
        public static implicit operator GetBadgesArgs(string v) => new GetBadgesArgs(v);
    }
}

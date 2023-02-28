using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetChannelTeamsArgs : QueryMap
    {
        /// <summary> The ID of the broadcaster whose teams you want to get. </summary>
        public string BroadcasterId { get; set; }

        public GetChannelTeamsArgs() { }
        public GetChannelTeamsArgs(string broadcasterId)
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

        public static implicit operator string(GetChannelTeamsArgs value) => value.BroadcasterId;
        public static implicit operator GetChannelTeamsArgs(string v) => new GetChannelTeamsArgs(v);
    }
}

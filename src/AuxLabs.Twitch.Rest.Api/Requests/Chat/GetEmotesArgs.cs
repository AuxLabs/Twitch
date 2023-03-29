using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetEmotesArgs : QueryMap
    {
        /// <summary> An ID that identifies the broadcaster whose emotes you want to get. </summary>
        public string BroadcasterId { get; set; }

        public GetEmotesArgs() { }
        public GetEmotesArgs(string broadcasterId)
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

        public static implicit operator string(GetEmotesArgs value) => value.BroadcasterId;
        public static implicit operator GetEmotesArgs(string v) => new GetEmotesArgs(v);
    }
}

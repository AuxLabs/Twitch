using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class GetCurrentTrackArgs : QueryMap
    {
        /// <summary> The ID of the broadcaster that’s playing a Soundtrack track. </summary>
        public string BroadcasterId { get; set; }

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
    }
}

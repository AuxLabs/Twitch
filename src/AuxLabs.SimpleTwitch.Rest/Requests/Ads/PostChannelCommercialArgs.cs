using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostChannelCommercialArgs : QueryMap, IScoped
    {
        public string[] Scopes { get; } = { "channel:edit:commercial" };

        /// <summary> The ID of the partner or affiliate broadcaster that wants to run the commercial. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> Optional, the length of the commercial to run, in seconds. </summary>
        /// <remarks> If specified, the minimum value is 1 and the maximum value is 180. </remarks>
        public int? Length { get; set; }

        public PostChannelCommercialArgs() { }
        public PostChannelCommercialArgs(string broadcasterId, int? length = null)
        {
            BroadcasterId = broadcasterId;
            Length = length;
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.AtLeast(Length, 1, nameof(Length));
            Require.AtMost(Length, 180, nameof(Length));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };

            if (Length != null)
                map["length"] = Length.ToString();
            
            return map;
        }
    }
}

using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostChannelCommercialArgs : QueryMap<string>, IScoped
    {
        public static string[] Scopes { get; } = { "channel:edit:commercial" };

        /// <summary> The ID of the partner or affiliate broadcaster that wants to run the commercial. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The length of the commercial to run, in seconds. </summary>
        /// <remarks> If specified, the minimum value is 1 and the maximum value is 180. </remarks>
        public int? Length { get; set; }

        public PostChannelCommercialArgs() { }
        public PostChannelCommercialArgs(string broadcasterId, int length)
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

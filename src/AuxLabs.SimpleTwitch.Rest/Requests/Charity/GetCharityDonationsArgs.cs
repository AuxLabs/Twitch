using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetCharityDonationsArgs : QueryMap, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "channel:read:charity" };

        /// <summary> The ID of the broadcaster that’s currently running a charity campaign. </summary>
        public string BroadcasterId { get; set; }

        /// <inheritdoc />
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 20. </remarks>
        public int? First { get; set; }

        /// <inheritdoc />
        public string After { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };

            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;
            return map;
        }
    }
}

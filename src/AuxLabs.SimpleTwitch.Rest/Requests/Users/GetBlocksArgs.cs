using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetBlocksArgs : QueryMap, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "user:read:blocked_users" };

        /// <summary> The ID of the broadcaster whose list of blocked users you want to get. </summary>
        public string BroadcasterId { get; set; }

        public int? First { get; set; }
        public string After { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId)); 
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (After != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginated.Before { get; set; } = null;
    }
}

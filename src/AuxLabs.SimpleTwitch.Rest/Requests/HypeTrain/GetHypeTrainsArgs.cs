using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetHypeTrainsArgs : QueryMap, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "channel:read:hype_train" };

        /// <summary> The ID of the broadcaster that’s running the Hype Train. </summary>
        public string BroadcasterId { get; set; }

        /// <inheritdoc />
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 1. </remarks>
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
            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginated.Before { get; set; } = null;
    }
}

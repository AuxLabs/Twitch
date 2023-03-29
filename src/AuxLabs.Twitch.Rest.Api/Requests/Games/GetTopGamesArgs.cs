using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class GetTopGamesArgs : QueryMap, IPaginatedRequest
    {
        /// <inheritdoc/>
        /// <remarks> The minimum page size is 1 and the maximum is 100. Default is 20. </remarks>
        public int? First { get; set; }
        public string Before { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(Before, nameof(Before));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (First != null)
                map["first"] = First.Value.ToString();
            if (Before != null)
                map["before"] = Before;
            if (After != null)
                map["after"] = After;

            return map;
        }
    }
}

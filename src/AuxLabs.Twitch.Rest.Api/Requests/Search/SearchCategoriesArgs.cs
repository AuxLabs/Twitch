﻿using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class SearchCategoriesArgs : QueryMap, IPaginatedRequest
    {
        /// <summary> The search string. </summary>
        public string Query { get; set; }

        /// <inheritdoc />
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 1. </remarks>
        public int? First { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            Require.NotEmptyOrWhitespace(Query, nameof(Query));
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["query"] = Query
            };

            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginatedRequest.Before { get; set; } = null;
    }
}

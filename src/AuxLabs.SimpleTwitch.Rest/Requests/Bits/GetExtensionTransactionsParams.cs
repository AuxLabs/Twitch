using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetExtensionTransactionsParams : QueryMap<string[]>
    {
        /// <summary> The ID of the extension whose list of transactions you want to get. </summary>
        public string ExtensionId { get; set; }

        /// <summary> A collection of transaction ids used to filter the list of transactions. </summary>
        public IEnumerable<string> TransactionIds { get; set; } = null;

        /// <summary> The maximum number of items to return per page in the response. </summary>
        /// <remarks> If specified, the minimum value is 1 and the maximum value is 100. </remarks>
        public int? First { get; set; } = null;

        /// <summary> The cursor used to get the next page of results. </summary>
        public string After { get; set; } = null;

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();
            if (ExtensionId != null)
                map["extension_id"] = new[] { ExtensionId };
            if (First != null)
                map["first"] = new[] { First.ToString() };
            if (After != null)
                map["after"] = new[] { After };
            if (TransactionIds != null)
            {
                var list = new List<string>();
                foreach (var id in TransactionIds)
                    list.Add(id);
                map["id"] = list.ToArray();
            }
            return map;
        }
    }
}

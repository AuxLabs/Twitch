using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetExtensionTransactionsArgs : QueryMap<string[]>, IPaginated
    {
        /// <summary> The ID of the extension whose list of transactions you want to get. </summary>
        public string ExtensionId { get; set; }

        /// <summary> Optional, a collection of transaction ids used to filter the list of transactions. </summary>
        /// <remarks> The minimum amount of items is 1 the maximum is 100. </remarks>
        public List<string> TransactionIds { get; set; }

        /// <inheritdoc/>
        /// <remarks> Optional, the minimum value is 1 the maximum is 100, defaults to 20. </remarks>
        public int? First { get; set; }

        public string After { get; set; }

        public void Validate()
        {
            Require.NotNullOrWhitespace(ExtensionId, nameof(ExtensionId));
            Require.HasAtLeast(TransactionIds, 1, nameof(TransactionIds));
            Require.HasAtMost(TransactionIds, 100, nameof(TransactionIds));
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>
            {
                ["extension_id"] = new[] { ExtensionId }
            };

            if (TransactionIds != null)
                map["id"] = TransactionIds.ToArray();
            if (First != null)
                map["first"] = new[] { First.ToString() };
            if (After != null)
                map["after"] = new[] { After };
            
            return map;
        }

        string IPaginated.Before { get; set; } = null;
    }
}

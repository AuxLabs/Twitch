using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetPredictionsArgs : QueryMap<string[]>, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "channel:read:predictions", "channel:manage:predictions" };

        /// <summary> The ID of the broadcaster whose predictions you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The IDs of the predictions to get. </summary>
        public List<string> PredictionIds { get; set; }

        public int? First { get; set; }
        public string After { get; set; }

        public GetPredictionsArgs() { }
        public GetPredictionsArgs(string broadcasterid, params string[] predictionIds)
        {
            PredictionIds = predictionIds.ToList();
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.HasAtLeast(PredictionIds, 1, nameof(PredictionIds));
            Require.HasAtMost(PredictionIds, 25, nameof(PredictionIds));
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();
            
            if (BroadcasterId != null)
                map["broadcaster_id"] = new[] { BroadcasterId };
            if (PredictionIds?.Count > 0)
                map["id"] = PredictionIds.ToArray();
            if (First != null)
                map["first"] = new[] { First.Value.ToString() };
            if (After != null)
                map["after"] = new[] { After };

            return map;
        }

        string IPaginated.Before { get; set; }
    }
}

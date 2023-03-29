using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetEmoteSetsArgs : QueryMap
    {
        /// <summary> A collection of IDs that identify the emote sets to get. </summary>
        /// <remarks> You may specify a maximum of 25 IDs. </remarks>
        public string[] EmoteSetIds { get; set; }

        public GetEmoteSetsArgs() { }
        public GetEmoteSetsArgs(params string[] emoteSets)
        {
            EmoteSetIds = emoteSets;
        }

        public void Validate()
        {
            Require.NotNull(EmoteSetIds, nameof(EmoteSetIds));
            Require.HasAtLeast(EmoteSetIds, 1, nameof(EmoteSetIds));
            Require.HasAtMost(EmoteSetIds, 100, nameof(EmoteSetIds));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            foreach (var item in EmoteSetIds)
                map["emote_set_id"] = item;

            return map;
        }

        public static implicit operator string[](GetEmoteSetsArgs value) => value.EmoteSetIds.ToArray();
        public static implicit operator GetEmoteSetsArgs(string[] v) => new GetEmoteSetsArgs(v);
    }
}

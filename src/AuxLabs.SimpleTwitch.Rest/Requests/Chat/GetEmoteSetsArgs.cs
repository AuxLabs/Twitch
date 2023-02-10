using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetEmoteSetsArgs : QueryMap<string[]>
    {
        /// <summary> A collection of IDs that identify the emote sets to get. </summary>
        /// <remarks> You may specify a maximum of 25 IDs. </remarks>
        public List<string> EmoteSetIds { get; set; }

        public GetEmoteSetsArgs() { }
        public GetEmoteSetsArgs(params string[] emoteSets)
        {
            EmoteSetIds = emoteSets.ToList();
        }
        public GetEmoteSetsArgs(List<string> emoteSets)
        {
            EmoteSetIds = emoteSets;
        }

        public void Validate()
        {
            Require.NotNull(EmoteSetIds, nameof(EmoteSetIds));
            Require.HasAtLeast(EmoteSetIds, 1, nameof(EmoteSetIds));
            Require.HasAtMost(EmoteSetIds, 100, nameof(EmoteSetIds));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            return new Dictionary<string, string[]>
            {
                ["emote_set_id"] = EmoteSetIds.ToArray()
            };
        }

        public static implicit operator string[](GetEmoteSetsArgs value) => value.EmoteSetIds.ToArray();
        public static implicit operator GetEmoteSetsArgs(string[] v) => new GetEmoteSetsArgs(v);
        public static implicit operator List<string>(GetEmoteSetsArgs value) => value.EmoteSetIds;
        public static implicit operator GetEmoteSetsArgs(List<string> v) => new GetEmoteSetsArgs(v);
    }
}

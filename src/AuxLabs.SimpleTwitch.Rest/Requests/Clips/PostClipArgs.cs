using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostClipArgs : QueryMap, IScoped
    {
        public string[] Scopes { get; } = { "clips:edit" };

        /// <summary> The ID of the broadcaster whose stream you want to create a clip from. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> Determines whether the API captures the clip at the moment the viewer requests it or after a delay. </summary>
        public bool? HasDelay { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId,
            };

            if (HasDelay != null)
                map["has_delay"] = HasDelay.ToString();
            return map;
        }
    }
}

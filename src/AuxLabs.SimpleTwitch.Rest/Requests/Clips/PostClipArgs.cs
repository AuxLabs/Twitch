using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostClipArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "clips:edit" };

        /// <summary> The ID of the broadcaster whose stream you want to create a clip from. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> Determines whether the API captures the clip at the moment the viewer requests it or after a delay. </summary>
        public bool? HasDelay { get; set; }

        public PostClipArgs() { }
        public PostClipArgs(string broadcasterId, bool? hasDelay = null)
        {
            BroadcasterId = broadcasterId;
            HasDelay = hasDelay;
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (HasDelay != null)
                map["has_delay"] = HasDelay.ToString();

            return map;
        }

        public static implicit operator string(PostClipArgs value) => value.BroadcasterId;
        public static implicit operator PostClipArgs(string v) => new PostClipArgs(v);
    }
}

using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class DeleteVideosArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "channel:manage:videos" };

        /// <summary> The collection of video ids to delete. </summary>
        public string[] VideoIds { get; set; }

        public DeleteVideosArgs() { }
        public DeleteVideosArgs(params string[] videoIds)
        {
            VideoIds = videoIds;
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNull(VideoIds, nameof(VideoIds));
            Require.HasAtLeast(VideoIds, 1, nameof(VideoIds));
            Require.HasAtMost(VideoIds, 5, nameof(VideoIds));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            foreach (var item in VideoIds)
                map["id"] = item;

            return map;
        }

        public static implicit operator string[](DeleteVideosArgs value) => value.VideoIds.ToArray();
        public static implicit operator DeleteVideosArgs(string[] v) => new DeleteVideosArgs(v);
    }
}
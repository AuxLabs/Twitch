using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class DeleteVideosArgs : QueryMap<string[]>, IScoped
    {
        public string[] Scopes { get; } = { "channel:manage:videos" };

        /// <summary> The collection of video ids to delete. </summary>
        public List<string> VideoIds { get; set; }

        public DeleteVideosArgs() { }
        public DeleteVideosArgs(params string[] videoIds)
        {
            VideoIds = videoIds.ToList();
        }
        public DeleteVideosArgs(List<string> videoIds)
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

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            return new Dictionary<string, string[]>
            {
                ["id"] = VideoIds.ToArray()
            };
        }

        public static implicit operator string[](DeleteVideosArgs value) => value.VideoIds.ToArray();
        public static implicit operator DeleteVideosArgs(string[] v) => new DeleteVideosArgs(v);
        public static implicit operator List<string>(DeleteVideosArgs value) => value.VideoIds;
        public static implicit operator DeleteVideosArgs(List<string> v) => new DeleteVideosArgs(v);
    }
}
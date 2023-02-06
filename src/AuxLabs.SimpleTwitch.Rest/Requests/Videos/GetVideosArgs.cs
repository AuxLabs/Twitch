using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetVideosArgs : QueryMap<string[]>
    {
        public List<string> VideoIds { get; set; } = default;
        public string UserId { get; set; }
        public string GameId { get; set; }
        public string Language { get; set; }
        public VideoPeriod? Period { get; set; }
        public VideoSort? Sort { get; set; }
        public VideoType? Type { get; set; }
        public int? First { get; set; }
        public string After { get; set; }
        public string Before { get; set; }

        public GetVideosArgs() { }
        public GetVideosArgs(params string[] videoIds)
        {
            VideoIds = videoIds.ToList();
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();
            
            if (VideoIds != default)
                map["id"] = VideoIds.ToArray();
            if (UserId != null)
                map["user_id"] = new[] { UserId };
            if (GameId != null)
                map["game_id"] = new[] { GameId };
            if (Language != null)
                map["language"] = new[] { Language };
            if (Period != null)
                map["period"] = new[] { Period.Value.GetEnumMemberValue() };
            if (Sort != null)
                map["sort"] = new[] { Sort.Value.GetEnumMemberValue() };
            if (Type != null)
                map["type"] = new[] { Type.Value.GetEnumMemberValue() };
            if (First != null)
                map["first"] = new[] { First.ToString() };
            if (After != null)
                map["after"] = new[] { After };
            if (Before != null)
                map["before"] = new[] { Before };

            return map;
        }
    }
}

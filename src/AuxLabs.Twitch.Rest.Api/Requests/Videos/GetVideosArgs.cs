using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class GetVideosArgs : QueryMap, IPaginatedRequest
    {
        /// <summary> A collection of IDs that identify the videos you want to get. </summary>
        public string[] VideoIds { get; set; }

        /// <summary> The ID of the user whose list of videos you want to get. </summary>
        public string UserId { get; set; }

        /// <summary> A category or game ID. </summary>
        public string GameId { get; set; }

        /// <summary> Filter the list of videos by the language that the video owner broadcasts in. </summary>
        public string Language { get; set; }

        /// <summary> Filter the list of videos by when they were published. </summary>
        public VideoPeriod? Period { get; set; }

        /// <summary> The order to sort the returned videos in. </summary>
        public VideoSort? Sort { get; set; }

        /// <summary> Filter the list of videos by the video’s type. </summary>
        public VideoType? Type { get; set; }

        public int? First { get; set; }
        public string After { get; set; }
        public string Before { get; set; }

        public void Validate()
        {
            Require.Exclusive(new object[] { VideoIds, UserId, GameId }, new[] { nameof(VideoIds), nameof(UserId), nameof(GameId) });
            Require.NotEmptyOrWhitespace(Language, nameof(Language));

            Require.Exclusive(new object[] { Before, After }, new[] { nameof(Before), nameof(After) });
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(Before, nameof(Before));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);
            
            if (VideoIds?.Length > 0)
            {
                foreach (var item in VideoIds)
                    map["id"] = item;
            }
            if (UserId != null)
                map["user_id"] = UserId;
            if (GameId != null)
                map["game_id"] = GameId;
            if (Language != null)
                map["language"] = Language;
            if (Period != null)
                map["period"] = Period.Value.GetStringValue();
            if (Sort != null)
                map["sort"] = Sort.Value.GetStringValue();
            if (Type != null)
                map["type"] = Type.Value.GetStringValue();
            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;
            if (Before != null)
                map["before"] = Before;

            return map;
        }
    }
}

using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetPlaylistsArgs : QueryMap, IPaginatedRequest
    {
        /// <summary> The ID of the playlist to get. </summary>
        public string PlaylistId { get; set; }

        /// <inheritdoc />
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 1. </remarks>
        public int? First { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            Require.NotEmptyOrWhitespace(PlaylistId, nameof(PlaylistId));
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            
            if (PlaylistId != null)
                map["id"] = PlaylistId;
            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginatedRequest.Before { get; set; } = null;
    }
}

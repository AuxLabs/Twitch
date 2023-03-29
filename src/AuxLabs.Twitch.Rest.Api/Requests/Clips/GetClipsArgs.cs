using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.Twitch.Rest
{
    public class GetClipsArgs : QueryMap, IPaginatedRequest
    {
        /// <summary> An ID that identifies the broadcaster whose video clips you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> An ID that identifies the game whose clips you want to get. </summary>
        public string GameId { get; set; }

        /// <summary> An ID that identifies the clip to get. </summary>
        /// <remarks> You may specify a maximum of 100 IDs. </remarks>
        public string[] ClipIds { get; set; }

        /// <summary> The start date used to filter clips. </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary> The end date used to filter clips. </summary>
        public DateTime? EndedAt { get; set; }

        /// <inheritdoc/>
        /// <remarks> The minimum page size is 1 and the maximum is 100. </remarks>
        public int? First { get; set; }
        public string Before { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            Require.Exclusive(new object[] { BroadcasterId, GameId, ClipIds }, new[] { nameof(BroadcasterId), nameof(GameId), nameof(ClipIds) });
            Require.NotEmptyOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotEmptyOrWhitespace(GameId, nameof(GameId));
            Require.HasAtLeast(ClipIds, 1, nameof(ClipIds));
            Require.HasAtMost(ClipIds, 100, nameof(ClipIds));

            Require.Exclusive(new object[] { Before, After }, new[] { nameof(Before), nameof(After) });
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(Before, nameof(Before));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance);

            if (BroadcasterId != null) 
                map["broadcaster_id"] = BroadcasterId;
            if (GameId != null)
                map["game_id"] = GameId;
            if (ClipIds?.Length > 0)
            {
                foreach (var item in ClipIds)
                    map["id"] = item;
            }
            if (StartedAt != null)
                map["started_at"] = XmlConvert.ToString(StartedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (EndedAt != null)
                map["ended_at"] = XmlConvert.ToString(EndedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (First != null)
                map["first"] = First.Value.ToString();
            if (Before != null)
                map["before"] = Before;
            if (After != null)
                map["after"] = After;

            return map;
        }
    }
}

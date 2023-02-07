using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetClipsArgs : QueryMap<string[]>, IPaginated
    {
        /// <summary> An ID that identifies the broadcaster whose video clips you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> An ID that identifies the game whose clips you want to get. </summary>
        public string GameId { get; set; }

        /// <summary> An ID that identifies the clip to get. </summary>
        public List<string> ClipIds { get; set; }

        /// <summary> The start date used to filter clips. </summary>
        public DateTime StartedAt { get; set; }

        /// <summary> The end date used to filter clips. </summary>
        public DateTime EndedAt { get; set; }

        public int? First { get; set; }
        public string Before { get; set; }
        public string After { get; set; }


        public override IDictionary<string, string[]> CreateQueryMap()
        {
            var map = new Dictionary<string, string[]>();

            if (BroadcasterId != null) 
                map["broadcaster_id"] = new[] { BroadcasterId };
            if (GameId != null)
                map["game_id"] = new[] { GameId };
            if (ClipIds.Count > 0)
                map["id"] = ClipIds.ToArray();
            if (StartedAt != null)
                map["started_at"] = new[] { XmlConvert.ToString(StartedAt, XmlDateTimeSerializationMode.Utc) };
            if (EndedAt != null)
                map["ended_at"] = new[] { XmlConvert.ToString(EndedAt, XmlDateTimeSerializationMode.Utc) };
            if (First != null)
                map["first"] = new[] { First.Value.ToString() };
            if (Before != null)
                map["before"] = new[] { Before };
            if (After != null)
                map["after"] = new[] { After };

            return map;
        }
    }
}

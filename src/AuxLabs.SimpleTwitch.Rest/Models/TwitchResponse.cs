using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TwitchResponse<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("total")]
        public int? Total { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("date_range")]
        public DateRange? DateRange { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination? Pagination { get; }
    }

    public struct Pagination
    {
        /// <summary>
        /// Marks the top of the next page of results following a request.
        /// </summary>
        [JsonPropertyName("cursor")]
        public string Cursor { get; }
    }
}

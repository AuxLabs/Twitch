using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class TwitchResponse<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("data")]
        public IEnumerable<T>? Data { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("total")]
        public int? Total { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("date_range")]
        public DateRange? DateRange { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination? Pagination { get; init; }
    }

    public struct Pagination
    {
        /// <summary>
        /// Marks the top of the next page of results following a request.
        /// </summary>
        [JsonPropertyName("cursor")]
        public string Cursor { get; init; }
    }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary> An object that represents data returned by a Twitch request. </summary>
    public class TwitchResponse<T> where T : class
    {
        /// <summary> A collection of objects returned from a request </summary>
        [JsonPropertyName("data")]
        public IReadOnlyCollection<T> Data { get; set; }
    }

    /// <summary> An object that represents data returned by a Twitch request, but with some metadata. </summary>
    public class TwitchMetaResponse<T> : TwitchResponse<T> where T : class
    {
        /// <summary> The total number of objects returned in <see cref="TwitchResponse.Data"/>. </summary>
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        /// <summary> The current number of subscriber points earned by this broadcaster. </summary>
        /// <remarks> Only returned for <see cref="ITwitchApi.GetSubscriptionsAsync(object)"/> </remarks>
        [JsonPropertyName("points")]
        public int? Points { get; set; }

        /// <summary> A range of dates relating to the objects returned in <see cref="TwitchResponse.Data"/>. </summary>
        [JsonPropertyName("date_range")]
        public DateRange? DateRange { get; set; }

        /// <summary> Contains information used to page through the list of results. </summary>
        [JsonPropertyName("pagination")]
        public Pagination? Pagination { get; set; }
    }

    /// <summary>  </summary>
    public struct Pagination
    {
        /// <summary> The cursor used to get the next page of results. </summary>
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}

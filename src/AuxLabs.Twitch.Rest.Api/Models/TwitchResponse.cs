﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    /// <summary> An object that represents data returned by a Twitch request. </summary>
    public class TwitchResponse<T> where T : class
    {
        /// <summary> A collection of objects returned from a request </summary>
        [JsonInclude, JsonPropertyName("data")]
        public IReadOnlyCollection<T> Data { get; internal set; }
    }

    /// <summary> An object that represents data returned by a Twitch request, but with some metadata. </summary>
    public class TwitchMetaResponse<T> : TwitchResponse<T> where T : class
    {
        /// <summary> The total number of objects returned in <see cref="TwitchResponse.Data"/>. </summary>
        [JsonInclude, JsonPropertyName("total")]
        public int? Total { get; internal set; }

        /// <summary> The current number of subscriber points earned by this broadcaster. </summary>
        /// <remarks> Only returned for <see cref="ITwitchApi.GetSubscriptionsAsync(GetSubscriptionsArgs)"/> </remarks>
        [JsonInclude, JsonPropertyName("points")]
        public int? Points { get; internal set; }

        /// <summary> A range of dates relating to the objects returned in <see cref="TwitchResponse.Data"/>. </summary>
        [JsonInclude, JsonPropertyName("date_range")]
        public DateRange? DateRange { get; internal set; }

        /// <summary> Contains information used to page through the list of results. </summary>
        [JsonInclude, JsonPropertyName("pagination")]
        public Pagination? Pagination { get; internal set; }
    }

    /// <summary>  </summary>
    public struct Pagination
    {
        /// <summary> The cursor used to get the next page of results. </summary>
        [JsonInclude, JsonPropertyName("cursor")]
        public string Cursor { get; internal set; }
    }
}
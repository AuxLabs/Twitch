using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class EventSubResponse : TwitchResponse<EventSubscription>
    {
        /// <summary> The total number of subscriptions you’ve created. </summary>
        [JsonInclude, JsonPropertyName("total")]
        public int Total { get; internal set; }

        /// <summary> The sum of all of your subscription costs. </summary>
        [JsonInclude, JsonPropertyName("total_cost")]
        public int TotalCost { get; internal set; }

        /// <summary> The maximum total cost that you’re allowed to incur for all subscriptions you create. </summary>
        [JsonInclude, JsonPropertyName("max_total_cost")]
        public int MaxTotalCost { get; internal set; }

        /// <summary> Contains information used to page through the list of results. </summary>
        [JsonInclude, JsonPropertyName("pagination")]
        public Pagination Pagination { get; internal set; }
    }
}

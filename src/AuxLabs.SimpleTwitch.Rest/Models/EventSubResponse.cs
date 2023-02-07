using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EventSubResponse : TwitchResponse<EventSub>
    {
        /// <summary> The total number of subscriptions you’ve created. </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary> The sum of all of your subscription costs. </summary>
        [JsonPropertyName("total_cost")]
        public int TotalCost { get; set; }

        /// <summary> The maximum total cost that you’re allowed to incur for all subscriptions you create. </summary>
        [JsonPropertyName("max_total_cost")]
        public int MaxTotalCost { get; set; }

        /// <summary> Contains information used to page through the list of results. </summary>
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.API
{
    internal class RestData<T>
    {
        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination? Pagination { get; set; }
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonConstructor]
        public RestData(IEnumerable<T> data, Pagination? pagination = null, int? total = null)
            => (Data, Pagination, Total) = (data, Pagination, total);
    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.API
{
    internal class Pagination
    {
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

        [JsonConstructor]
        internal Pagination(string cursor)
            => Cursor = cursor;
    }
}

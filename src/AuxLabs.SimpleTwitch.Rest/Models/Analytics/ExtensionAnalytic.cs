using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class ExtensionAnalytic : Analytic
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; init; }

    }
}

using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ExtensionAnalytic : Analytic
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; }

    }
}

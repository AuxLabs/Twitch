using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary> Indicates that a method requires special authentication to be used. </summary>
    public interface IScoped
    {
        /// <summary> The scopes required for this request. </summary>
        [JsonIgnore]
        string[] Scopes { get; }

        void Validate(IEnumerable<string> scopes);
    }
}

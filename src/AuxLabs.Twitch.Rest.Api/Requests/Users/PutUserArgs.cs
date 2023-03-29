using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class PutUserArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "user:edit" };

        /// <summary> The string to update the channel’s description to. </summary>
        public string Description { get; set; }

        public PutUserArgs() { }
        public PutUserArgs(string description)
        {
            Description = description;
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(Description, nameof(Description));
            Require.LengthAtLeast(Description, 1, nameof(Description));
            Require.LengthAtMost(Description, 300, nameof(Description));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["description"] = Description
            };
        }

        public static implicit operator string(PutUserArgs value) => value.Description;
        public static implicit operator PutUserArgs(string v) => new PutUserArgs(v);
    }
}

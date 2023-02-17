using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CodeStatusArgs : QueryMap<string[]>
    {
        /// <summary> The redemption codes to check. </summary>
        /// <remarks> You may specify a maximum of 20 codes. </remarks>
        public List<string> Codes { get; set; }

        /// <summary> The ID of the user that owns the redemption code. </summary>
        public string UserId { get; set; }

        public void Validate()
        {
            Require.NotNull(Codes, nameof(Codes));
            Require.HasAtLeast(Codes, 1, nameof(Codes));
            Require.HasAtMost(Codes, 20, nameof(Codes));

            Require.NotNullOrWhitespace(UserId, nameof(UserId));
        }

        public override IDictionary<string, string[]> CreateQueryMap()
        {
            return new Dictionary<string, string[]>
            {
                ["code"] = Codes.ToArray(),
                ["user_id"] = new[] { UserId }
            };
        }
    }
}

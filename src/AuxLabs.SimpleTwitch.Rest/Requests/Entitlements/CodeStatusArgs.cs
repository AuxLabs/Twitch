using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CodeStatusArgs : QueryMap
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

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance)
            {
                ["user_id"] = UserId
            };

            foreach (var item in Codes)
                map["code"] = item;

            return map;
        }
    }
}

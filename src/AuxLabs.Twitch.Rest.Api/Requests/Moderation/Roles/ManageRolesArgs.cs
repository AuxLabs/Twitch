using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public abstract class ManageRolesArgs : QueryMap
    {
        /// <summary> The ID of the broadcaster that owns the chat room. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the user to add or remove a role from in the broadcaster’s chat room. </summary>
        public string UserId { get; set; }

        public void Validate()
        {
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(UserId, nameof(UserId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId,
                ["user_id"] = UserId
            };
        }
    }
}

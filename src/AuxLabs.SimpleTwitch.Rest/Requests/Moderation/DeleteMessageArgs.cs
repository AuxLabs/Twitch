using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class DeleteMessageArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "moderator:manage:chat_messages" };

        /// <summary> The ID of the broadcaster that owns the chat room to remove messages from. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster or a user that has permission to moderate the broadcaster’s chat room. </summary>
        public string ModeratorId { get; set; }

        /// <summary> The ID of the message to remove. </summary>
        /// <remarks> The message must have been created within the last 6 hours, not belong to the broadcaster, and not belong to another moderator. </remarks>
        public string MessageId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(ModeratorId, authedUserId, nameof(ModeratorId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(ModeratorId, nameof(ModeratorId));
            Require.NotEmptyOrWhitespace(MessageId, nameof(MessageId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId,
                ["moderator_id"] = ModeratorId
            };

            if (MessageId != null) 
                map["message_id"] = MessageId;

            return map;
        }
    }
}

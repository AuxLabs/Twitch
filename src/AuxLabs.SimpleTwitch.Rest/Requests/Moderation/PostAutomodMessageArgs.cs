using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostAutomodMessageArgs : QueryMap, IScoped
    {
        public string[] Scopes { get; } = { "moderator:manage:automod" };

        /// <summary> The moderator who is approving or denying the held message. </summary>
        public string UserId { get; set; }

        /// <summary> The ID of the message to allow or deny. </summary>
        public string MessageId { get; set; }

        /// <summary> The action to take for the message. </summary>
        public AutomodAction Action { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>()
            {
                ["user_id"] = UserId,
                ["msg_id"] = MessageId,
                ["action"] = Action.GetEnumMemberValue()
            };
        }
    }
}

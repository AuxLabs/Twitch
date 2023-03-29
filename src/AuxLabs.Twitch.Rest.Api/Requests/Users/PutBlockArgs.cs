using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PutBlockArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "user:manage:blocked_users" };

        /// <summary> The ID of the user to block. </summary>
        public string TargetUserId { get; set; }

        /// <summary> The location where the harassment took place that is causing the brodcaster to block the user. </summary>
        public BlockContext? Context { get; set; }

        /// <summary> The reason that the broadcaster is blocking the user. </summary>
        public string Reason { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(TargetUserId, nameof(TargetUserId));
            Require.NotEmptyOrWhitespace(Reason, nameof(Reason));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (TargetUserId != null)
                map["target_user_id"] = TargetUserId;
            if (Context != null)
                map["source_context"] = Context.Value.GetStringValue();
            if (Reason != null)
                map["reason"] = Reason;

            return map;
        }
    }
}

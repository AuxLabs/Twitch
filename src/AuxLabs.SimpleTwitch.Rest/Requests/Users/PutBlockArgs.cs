﻿using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PutBlockArgs : QueryMap, IScoped
    {
        public string[] Scopes { get; } = { "user:manage:blocked_users" };

        /// <summary> The ID of the user to block. </summary>
        public string TargetUserId { get; set; }

        /// <summary> The location where the harassment took place that is causing the brodcaster to block the user. </summary>
        public BlockContext? Context { get; set; }

        /// <summary> The reason that the broadcaster is blocking the user. </summary>
        public string Reason { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            if (TargetUserId != null)
                map["target_user_id"] = TargetUserId;
            if (Context != null)
                map["source_context"] = Context.Value.GetEnumMemberValue();
            if (Reason != null)
                map["reason"] = Reason;
            return map;
        }
    }
}

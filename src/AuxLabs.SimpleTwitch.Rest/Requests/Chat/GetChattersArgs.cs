using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetChattersArgs : QueryMap, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "moderator:read:chatters" };

        /// <summary> The ID of the broadcaster whose list of chatters you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster or one of the broadcaster’s moderators. </summary>
        public string ModeratorId { get; set; }

        /// <inheritdoc />
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 20. </remarks>
        public int? First { get; set; }

        public string After { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(ModeratorId, nameof(ModeratorId));
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            
            if (BroadcasterId != null)
                map["broadcaster_id"] = BroadcasterId;
            if (ModeratorId != null)
                map["moderator_id"] = ModeratorId;
            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginated.Before { get; set; } = null;
    }
}

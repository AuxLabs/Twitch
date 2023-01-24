using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class GlobalUserStateTags : BaseTags
    {
        /// <summary>
        /// The user’s ID.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The type of user.
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// The user’s display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The color of the user’s name in the chat room.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// A collection of badges the user has.
        /// </summary>
        public IReadOnlyCollection<Badge> Badges { get; set; }

        /// <summary>
        /// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
        /// </summary>
        public string BadgeInfo { get; set; }

        /// <summary>
        /// A collection of IDs that identify the emote sets that the user has access to.
        /// </summary>
        public IReadOnlyCollection<string> EmoteSets { get; set; }

        /// <summary>
        /// Indicates whether the user has site-wide commercial free mode enabled.
        /// </summary>
        public bool IsTurbo { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["user-id"] = UserId,
                ["user-type"] = UserType.GetEnumMemberValue(),
                ["display-name"] = DisplayName,
                ["color"] = ColorTranslator.ToHtml(Color),
                ["badges"] = string.Join(',', Badges),
                ["badge-info"] = BadgeInfo,
                ["emote-sets"] = string.Join(',', EmoteSets),
                ["turbo"] = IsTurbo ? "1" : "0"
            };
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("user-id", out string str))
                UserId = str;
            if (map.TryGetValue("user-type", out str))
                UserType = EnumHelper.GetValueFromEnumMember<UserType>(str);
            if (map.TryGetValue("display-name", out str))
                DisplayName = str;
            if (map.TryGetValue("color", out str))
                Color = ColorTranslator.FromHtml(str);
            if (map.TryGetValue("badges", out str))
            {
                if (Badge.TryParseMany(str, out var badges))
                    Badges = badges;
            }
            if (map.TryGetValue("badge-info", out str))
                BadgeInfo = str;
            if (map.TryGetValue("emote-sets", out str))
                EmoteSets = str.Split(',');
            if (map.TryGetValue("turbo", out str))
                IsTurbo = str == "1";
        }
    }
}

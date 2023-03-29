using System.Collections.Generic;
using System.Drawing;

namespace AuxLabs.Twitch.Chat
{
    public class GlobalUserStateTags : BaseTags
    {
        /// <summary> The user’s ID. </summary>
        public string UserId { get; internal set; }

        /// <summary> The type of user. </summary>
        public UserType UserType { get; internal set; }

        /// <summary> The user’s display name. </summary>
        public string UserDisplayName { get; internal set; }

        /// <summary> The color of the user’s name in the chat room. </summary>
        public Color Color { get; internal set; }

        /// <summary> A collection of badges the user has. </summary>
        public IReadOnlyCollection<Badge> Badges { get; internal set; }

        /// <summary> Contains metadata related to the chat badges in the badges tag. </summary>
        /// <remarks> Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber. </remarks>
        public string BadgeInfo { get; internal set; }

        /// <summary> A collection of IDs that identify the emote sets that the user has access to. </summary>
        public IReadOnlyCollection<string> EmoteSets { get; internal set; }

        /// <summary> Indicates whether the user has site-wide commercial free mode enabled. </summary>
        public bool IsTurbo { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["user-id"] = UserId,
                ["user-type"] = UserType.GetStringValue(),
                ["display-name"] = UserDisplayName,
                ["color"] = ColorTranslator.ToHtml(Color),
                ["badges"] = Badges == null ? null : string.Join(',', Badges),
                ["badge-info"] = BadgeInfo,
                ["emote-sets"] = EmoteSets == null ? null : string.Join(',', EmoteSets),
                ["turbo"] = IsTurbo ? "1" : "0"
            };
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("user-id", out string str))
                UserId = str;
            if (map.TryGetValue("user-type", out str))
                UserType = EnumHelper.GetEnumValue<UserType>(str);
            if (map.TryGetValue("display-name", out str))
                UserDisplayName = str;
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

using System.Collections.Generic;
using System.Drawing;

namespace AuxLabs.Twitch.Chat.Models
{
    public class WhisperTags : BaseTags
    {
        /// <summary> An ID that uniquely identifies the message. </summary>
        public string MessageId { get; internal set; }

        /// <summary> An ID that uniquely identifies the whisper thread. </summary>
        public string ThreadId { get; internal set; }

        /// <summary> The ID of the user that sent the message. </summary>
        public string AuthorId { get; internal set; }

        /// <summary> The user’s display name. </summary>
        public string AuthorDisplayName { get; internal set; }

        /// <summary> The color of the user’s name in the chat room. </summary>
        public Color AuthorColor { get; internal set; }

        /// <summary> The type of user. </summary>
        public UserType AuthorType { get; internal set; }

        /// <summary> A collection of badges the user has. </summary>
        public IReadOnlyCollection<Badge> Badges { get; internal set; }

        /// <summary> A collection of emotes and their position in the message. </summary>
        public IReadOnlyCollection<EmotePosition> Emotes { get; internal set; }

        /// <summary> The message value when someone uses the /me chat command </summary>
        public string Action { get; internal set; }

        /// <summary> Indicates whether the user has site-wide commercial free mode enabled. </summary>
        public bool IsTurbo { get; internal set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["message-id"] = MessageId,
                ["thread-id"] = ThreadId,
                ["user-id"] = AuthorId,
                ["user-type"] = EnumHelper.GetStringValue(AuthorType),
                ["display-name"] = AuthorDisplayName,
                ["color"] = ColorTranslator.ToHtml(AuthorColor),
                ["badges"] = string.Join(',', Badges),
                ["emotes"] = Emotes != null ? string.Join(',', Emotes) : Action,
                ["turbo"] = IsTurbo ? "1" : "0"
            };
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("message-id", out string str))
                MessageId = str;
            if (map.TryGetValue("thread-id", out str))
                ThreadId = str;
            if (map.TryGetValue("user-id", out str))
                AuthorId = str;
            if (map.TryGetValue("user-type", out str))
                AuthorType = EnumHelper.GetEnumValue<UserType>(str);
            if (map.TryGetValue("display-name", out str))
                AuthorDisplayName = str;
            if (map.TryGetValue("color", out str))
                AuthorColor = ColorTranslator.FromHtml(str);
            if (map.TryGetValue("badges", out str))
            {
                if (Badge.TryParseMany(str, out var badges))
                    Badges = badges;
            }
            if (map.TryGetValue("emotes", out str))
            {
                if (EmotePosition.TryParseMany(str, out var emotes))
                    Emotes = emotes;
                else
                    Action = str;
            }
            if (map.TryGetValue("turbo", out str))
                IsTurbo = str == "1";
        }
    }
}

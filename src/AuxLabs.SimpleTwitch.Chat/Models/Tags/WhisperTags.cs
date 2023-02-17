using System.Collections.Generic;
using System;
using System.Drawing;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class WhisperTags : BaseTags
    {
        /// <summary> An ID that uniquely identifies the message. </summary>
        public string Id { get; set; }

        /// <summary> An ID that uniquely identifies the whisper thread. </summary>
        public string ThreadId { get; set; }

        /// <summary> The ID of the user that sent the message. </summary>
        public string UserId { get; set; }

        /// <summary> The type of user. </summary>
        public UserType UserType { get; set; }

        /// <summary> The user’s display name. </summary>
        public string DisplayName { get; set; }

        /// <summary> The color of the user’s name in the chat room. </summary>
        public Color Color { get; set; }

        /// <summary> A collection of badges the user has. </summary>
        public IReadOnlyCollection<Badge> Badges { get; set; }

        /// <summary> A collection of emotes and their position in the message. </summary>
        public IReadOnlyCollection<EmotePosition> Emotes { get; set; }

        /// <summary> The message value when someone uses the /me chat command </summary>
        public string Action { get; set; }

        /// <summary> Indicates whether the user has site-wide commercial free mode enabled. </summary>
        public bool IsTurbo { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["message-id"] = Id,
                ["thread-id"] = ThreadId,
                ["user-id"] = UserId,
                ["user-type"] = EnumHelper.GetStringValue(UserType),
                ["display-name"] = DisplayName,
                ["color"] = ColorTranslator.ToHtml(Color),
                ["badges"] = string.Join(',', Badges),
                ["emotes"] = Emotes != null ? string.Join(',', Emotes) : Action,
                ["turbo"] = IsTurbo ? "1" : "0"
            };
            return map;
        }
        public override void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("message-id", out string str))
                Id = str;
            if (map.TryGetValue("thread-id", out str))
                ThreadId = str;
            if (map.TryGetValue("user-id", out str))
                UserId = str;
            if (map.TryGetValue("user-type", out str))
                UserType = EnumHelper.GetEnumValue<UserType>(str);
            if (map.TryGetValue("display-name", out str))
                DisplayName = str;
            if (map.TryGetValue("color", out str))
                Color = ColorTranslator.FromHtml(str);
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

using AuxLabs.SimpleTwitch.Chat.Serialization;
using System.Drawing;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class MessageTags : QueryMap<string>
    {
        /// <summary>
        /// An ID that uniquely identifies the message.
        /// </summary>
        [IrcTagName("id")]
        public string Id { get; set; }

        /// <summary>
        /// An ID that identifies the channel.
        /// </summary>
        [IrcTagName("room-id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// The date and time that the message was sent.
        /// </summary>
        [IrcTagName("tmi-sent-ts")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The ID of the user that sent the message.
        /// </summary>
        [IrcTagName("user-id")]
        public string UserId { get; set; }

        /// <summary>
        /// The type of user.
        /// </summary>
        [IrcTagName("user-type")]
        public UserType UserType { get; set; }

        /// <summary>
        /// The user’s display name.
        /// </summary>
        [IrcTagName("display-name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The color of the user’s name in the chat room.
        /// </summary>
        [IrcTagName("color")]
        public Color Color { get; set; }

        /// <summary>
        /// A collection of badges the user has.
        /// </summary>
        [IrcTagName("badges")]
        public IReadOnlyCollection<Badge> Badges { get; set; }

        /// <summary>
        /// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
        /// </summary>
        [IrcTagName("badge-info")]
        public string BadgeInfo { get; set; }

        /// <summary>
        /// The amount of Bits the user cheered. Only a Bits cheer message includes this tag.
        /// </summary>
        [IrcTagName("bits")]
        public int Bits { get; set; }

        /// <summary>
        /// A collection of emotes and their position in the message.
        /// </summary>
        [IrcTagName("emotes")]
        public IReadOnlyCollection<EmotePosition> Emotes { get; set; }

        /// <summary>
        /// Indicates whether the user is a moderator.
        /// </summary>
        [IrcTagName("mod")]
        public bool IsMod { get; set; }

        /// <summary>
        /// Indicates whether the user is a subscriber.
        /// </summary>
        [IrcTagName("subscriber")]
        public bool IsSubscriber { get; set; }

        /// <summary>
        /// Indicates whether the user has site-wide commercial free mode enabled.
        /// </summary>
        [IrcTagName("turbo")]
        public bool IsTurbo { get; set; }

        /// <summary>
        /// Indicates whether the user is a VIP.
        /// </summary>
        [IrcTagName("vip")]
        public bool IsVIP { get; set; }

        /// <summary>
        /// An ID that uniquely identifies the parent message that this message is replying to.
        /// </summary>
        [IrcTagName("reply-parent-msg-id")]
        public string ReplyParentMessageId { get; set; }

        /// <summary>
        /// An ID that identifies the sender of the parent message.
        /// </summary>
        [IrcTagName("reply-parent-user-id")]
        public string ReplyParentUserId { get; set; }

        /// <summary>
        /// The login name of the sender of the parent message.
        /// </summary>
        [IrcTagName("reply-parent-user-login")]
        public string ReplyParentUserLogin { get; set; }

        /// <summary>
        /// The display name of the sender of the parent message.
        /// </summary>
        [IrcTagName("reply-parent-display-name")]
        public string ReplyParentDisplayName { get; set; }

        /// <summary>
        /// The text of the parent message.
        /// </summary>
        [IrcTagName("reply-parent-msg-body")]
        public string ReplyParentMessage { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            map["id"] = Id;
            map["room-id"] = ChannelId;
            map["tmi-sent-ts"] = Timestamp.ToUnixTimeMilliseconds().ToString();
            map["user-id"] = UserId;
            map["user-type"] = EnumHelper.GetEnumMemberValue(UserType);
            map["display-name"] = DisplayName;
            map["color"] = ColorTranslator.ToHtml(Color);
            map["badges"] = string.Join(',', Badges.Select(x => $"{x.Name}/{x.Version}"));
            map["badge-info"] = BadgeInfo;
            map["bits"] = Bits.ToString();
            map["emotes"] = string.Join(',', Emotes.Select(x => $"{x.Id}:{x.StartIndex}-{x.EndIndex}"));
            map["mod"] = IsMod ? "1" : "0";
            map["subscriber"] = IsSubscriber ? "1" : "0"; ;
            map["turbo"] = IsTurbo ? "1" : "0"; ;
            map["vip"] = IsVIP ? "1" : "0"; ;
            map["reply-parent-msg-id"] = ReplyParentMessageId;
            map["reply-parent-user-id"] = ReplyParentUserId;
            map["reply-parent-user-login"] = ReplyParentUserLogin;
            map["reply-parent-display-name"] = ReplyParentDisplayName;
            map["reply-parent-msg-body"] = ReplyParentMessage.Replace(" ", "\\s");
            return map;
        }
        public void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("id", out string str))
                Id = str;
            if (map.TryGetValue("room-id", out str))
                ChannelId = str;
            if (map.TryGetValue("tmi-sent-ts", out str))
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(str));
            if (map.TryGetValue("user-id", out str))
                UserId = str;
            if (map.TryGetValue("user-type", out str))
                UserType = EnumHelper.GetValueFromEnumMember<UserType>(str);
            if (map.TryGetValue("display-name", out str))
                DisplayName = str;
            if (map.TryGetValue("color", out str))
                Color = ColorTranslator.FromHtml(str);
            if (map.TryGetValue("badges", out str))
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    var badges = new List<Badge>();
                    var badgeArr = str.Split(',');
                    foreach (var item in badgeArr)
                    {
                        var info = item.Split('/');
                        badges.Add(new Badge(info[0], int.Parse(info[1])));
                    }
                    Badges = badges;
                }
            }
            if (map.TryGetValue("badge-info", out str))
                BadgeInfo = str;
            if (map.TryGetValue("bits", out str))
            {
                if (int.TryParse(str, out int bits))
                    Bits = bits;
                else
                    Bits = 0;
            }
            if (map.TryGetValue("emotes", out str))
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    var emotes = new List<EmotePosition>();
                    var emoteArr = str.Split(',');
                    string lastEmote = null;
                    foreach (var item in emoteArr)
                    {
                        var info = item.Split(':', '-');
                        bool useLast = info.Count() == 2;

                        var emote = new EmotePosition
                        {
                            Id = useLast ? lastEmote : info[0],
                            StartIndex = int.Parse(info[(useLast ? 0 : 1)]),
                            EndIndex = int.Parse(info[(useLast ? 1 : 2)]),
                        };

                        emotes.Add(emote);
                    }
                    Emotes = emotes;
                }
            }
            if (map.TryGetValue("mod", out str))
                IsMod = str == "1";
            if (map.TryGetValue("subscriber", out str))
                IsSubscriber = str == "1";
            if (map.TryGetValue("turbo", out str))
                IsTurbo = str == "1";
            if (map.TryGetValue("vip", out str))
                IsVIP = str == "1";
            if (map.TryGetValue("reply-parent-msg-id", out str))
                ReplyParentMessageId = str;
            if (map.TryGetValue("reply-parent-user-id", out str))
                ReplyParentUserId = str;
            if (map.TryGetValue("reply-parent-user-login", out str))
                ReplyParentUserLogin = str;
            if (map.TryGetValue("reply-parent-display-name", out str))
                ReplyParentDisplayName = str;
            if (map.TryGetValue("reply-parent-msg-body", out str))
                ReplyParentMessage = str;
        }
    }
}

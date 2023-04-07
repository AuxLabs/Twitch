using AuxLabs.Twitch.Chat.Models;
using AuxLabs.Twitch.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AuxLabs.Twitch.Chat.Api
{
    public sealed class DefaultIrcSerializer : ISerializer<IrcPayload>
    {
        private readonly bool _throwOnMismatchedTags;

        public DefaultIrcSerializer(bool throwOnMismatchedTags = false)
            => _throwOnMismatchedTags = throwOnMismatchedTags;

        public ReadOnlyMemory<byte> Write(IrcPayload msg)
        {
            var bytes = Encoding.UTF8.GetBytes(msg.ToString());
            return new ReadOnlyMemory<byte>(bytes);
        }

        public IrcPayload Read(ref ReadOnlySpan<byte> data)
        {
            var payload = new IrcPayload();

            Dictionary<string, string> tags = null;
            if (GetSection(ref data) == IrcTokenType.TagIndicator)
                tags = ReadTags(ref data);

            payload.Prefix = new IrcPrefix(ReadPrefix(ref data));
            if (payload.Prefix.ToString() == null) 
                return payload;

            payload.CommandRaw = ReadCommand(ref data);
            payload.Command = EnumHelper.GetEnumValue<IrcCommand>(payload.CommandRaw);
            payload.Parameters = ReadParameters(ref data);

            // Convert tags dictionary into compatible type
            if (tags != null && IrcPayload.TagsTypeSelector.TryGetValue(payload.Command, out var type))
            {
                if (type == typeof(UserNoticeTags))
                {
                    var notice = EnumHelper.GetEnumValue<UserNoticeType>(tags["msg-id"]);
                    if (IrcPayload.UserNoticeTypeSelector.TryGetValue(notice, out var noticeType))
                        payload.Tags = (UserNoticeTags)Activator.CreateInstance(noticeType);
                    else
                        payload.Tags = (UserNoticeTags)Activator.CreateInstance(type);
                }
                else
                {
                    payload.Tags = (BaseTags)Activator.CreateInstance(type);
                }

                if (_throwOnMismatchedTags)
                {
                    var expected = payload.Tags.CreateQueryMap();
                    if (expected.Count < tags.Count || !tags.All(x => expected.ContainsKey(x.Key)))
                        throw new UnexpectedTagsException(payload.CommandRaw, expected, tags);
                }

                payload.Tags.LoadQueryMap(tags);
            }

            return payload;
        }

        private static Dictionary<string, string> ReadTags(ref ReadOnlySpan<byte> remaining)
        {
            var tags = new Dictionary<string, string>();

            int i = 0;
            int start = 1;
            (string key, string value) tag = default;
            foreach (var c in remaining)
            {
                string value;
                ReadOnlySpan<byte> slice;
                switch (GetTagTokenType(c))
                {
                    // End of key found
                    case IrcTokenType.TagKeyValueSeparator:
                        slice = remaining[start..i];
                        value = Encoding.UTF8.GetString(slice);
                        tag.key = value;

                        i++;
                        start = i;
                        continue;

                    // End of value found
                    case IrcTokenType.TagKeyValueEnd:
                        slice = remaining[start..i];
                        value = Encoding.UTF8.GetString(slice);
                        tag.value = value;

                        tags.Add(tag.key, tag.value);
                        tag = default;

                        i++;
                        start = i;
                        continue;

                    // End of tags found
                    case IrcTokenType.TagEnd:
                        remaining = remaining[i..];
                        return tags;
                }

                i++;
            }

            remaining = remaining[i..];
            return tags;
        }

        private static string ReadPrefix(ref ReadOnlySpan<byte> remaining)
        {
            for (int i = 1; i < remaining.Length; i++)
            {
                var c = remaining[i];
                if (c == (byte)' ')
                {
                    var result = Encoding.UTF8.GetString(remaining[1..i]);
                    remaining = remaining[i..];
                    return result;
                }
            }
            remaining = remaining.Slice(0, remaining.Length - 1);
            return null;
        }

        private static string ReadCommand(ref ReadOnlySpan<byte> remaining)
        {
            for (int i = 1; i < remaining.Length; i++)
            {
                var c = remaining[i];
                if (c == (byte)'\r')
                {
                    var result = Encoding.UTF8.GetString(remaining[1..i]);
                    remaining = remaining[(i + 2)..];
                    return result;
                } else
                if (c == (byte)'#' || c == (byte)':' || char.IsLower((char)c))
                {
                    var result = Encoding.UTF8.GetString(remaining[1..(i - 1)]);
                    remaining = remaining[i..];
                    return result;
                }
            }
            return Encoding.UTF8.GetString(remaining).Trim();
        }

        private static IReadOnlyCollection<string> ReadParameters(ref ReadOnlySpan<byte> remaining)
        {
            var parameters = new List<string>();

            int i = 0;
            int start = 0;
            bool readToEnd = false;
            foreach (var c in remaining)
            {
                var n = remaining[i + 1];
                if (c == (byte)':' && !readToEnd)     // Read to end of message
                {
                    readToEnd = true;
                    start = i;
                } else
                if (c == (byte)' ' && !readToEnd)     // Parameter splitter
                {
                    parameters.Add(Encoding.UTF8.GetString(remaining[start..i]));
                    start = i;
                } else
                if (c == (byte)'\r' && n == (byte)'\n')     // End of message reached
                {
                    parameters.Add(Encoding.UTF8.GetString(remaining[start..i]));
                    remaining = remaining[(i + 2)..];
                    break;
                }
                i++;
            }
            return parameters.AsReadOnly();
        }

        private static IrcTokenType GetSection(ref ReadOnlySpan<byte> remaining)
        {
            for (int i = 0; i < remaining.Length; i++)
            {
                byte c = remaining[i];
                switch (c)
                {
                    case (byte)'@':
                        remaining = remaining[i..];
                        return IrcTokenType.TagIndicator;
                    case (byte)':':
                        remaining = remaining[i..];
                        return IrcTokenType.PrefixIndicator;
                }
            }

            return IrcTokenType.None;
        }

        private static IrcTokenType GetTagTokenType(byte c)
        {
            return c switch
            {
                (byte)'=' => IrcTokenType.TagKeyValueSeparator,
                (byte)';' => IrcTokenType.TagKeyValueEnd,
                (byte)' ' => IrcTokenType.TagEnd,
                _ => IrcTokenType.None,
            };
        }
    }
}

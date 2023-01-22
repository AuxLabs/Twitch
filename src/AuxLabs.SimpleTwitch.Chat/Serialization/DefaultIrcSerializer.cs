using AuxLabs.SimpleTwitch.Chat.Models;
using AuxLabs.SimpleTwitch.Sockets;
using System.Runtime.Serialization;
using System.Text;

namespace AuxLabs.SimpleTwitch.Chat.Serialization
{
    public sealed class DefaultIrcSerializer : ISerializer<IrcPayload>
    {
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
            payload.CommandRaw = ReadCommand(ref data);
            payload.Command = EnumHelper.GetValueFromEnumMember<IrcCommand>(payload.CommandRaw);
            payload.Parameters = ReadParameters(ref data);

            if (tags != null && IrcPayload.CommandTypeSelector.TryGetValue(payload.Command, out var type))
            {
                payload.Tags = (BaseTags)Activator.CreateInstance(type);
                payload.Tags.LoadQueryMap(tags);
            }

            return payload;
        }

        private static Dictionary<string, string> ReadTags(ref ReadOnlySpan<byte> remaining)
        {
            var input = Encoding.UTF8.GetString(remaining);
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
            var input = Encoding.UTF8.GetString(remaining);
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
            throw new SerializationException("Irc message prefix was not found.");
        }

        private static string ReadCommand(ref ReadOnlySpan<byte> remaining)
        {
            var input = Encoding.UTF8.GetString(remaining);
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
            var input = Encoding.UTF8.GetString(remaining);
            var parameters = new List<string>();

            int i = 0;
            int start = 0;
            bool readToEnd = false;
            foreach (var c in remaining)
            {
                var n = remaining[i + 1];
                if (c == (byte)':')     // Read to end of message
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
                    if (readToEnd)
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

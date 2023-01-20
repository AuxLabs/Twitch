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

            if (GetSection(ref data) == IrcTokenType.TagIndicator)
                payload.Tags = ReadTags(ref data);

            payload.Prefix = new IrcPrefix(ReadPrefix(ref data));
            payload.CommandRaw = ReadCommand(ref data);
            payload.Command = EnumHelper.GetValueFromEnumMember<IrcCommand>(payload.CommandRaw);
            payload.Parameters = ReadParameters(ref data);

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
            throw new SerializationException("Irc message prefix was not found.");
        }

        private static string ReadCommand(ref ReadOnlySpan<byte> remaining)
        {
            for (int i = 1; i < remaining.Length; i++)
            {
                var c = remaining[i];
                if (c == (byte)'#' || c == (byte)':' || char.IsLower((char)c))
                {
                    var result = Encoding.UTF8.GetString(remaining[1..(i - 1)]);
                    remaining = remaining[(i - 1)..];
                    return result;
                }
            }
            return Encoding.UTF8.GetString(remaining).Trim();
        }

        private static string ReadParameters(ref ReadOnlySpan<byte> remaining)
        {
            for (int i = 1; i < remaining.Length; i++)
            {
                var r = remaining[i];
                var n = remaining[i + 1];
                if (r == (byte)'\r' && n == (byte)'\n')
                {
                    var result = Encoding.UTF8.GetString(remaining[..i]).Trim();
                    remaining = remaining[(i + 2)..];
                    return result;
                }
            }
            return Encoding.UTF8.GetString(remaining).Trim();
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

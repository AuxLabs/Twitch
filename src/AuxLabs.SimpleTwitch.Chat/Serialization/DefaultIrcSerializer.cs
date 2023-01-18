using System.Runtime.Serialization;
using System.Text;

namespace AuxLabs.SimpleTwitch.Chat.Serialization
{
    public sealed class DefaultIrcSerializer : IIrcSerializer
    {
        public ReadOnlyMemory<byte> Write(IrcMessage msg)
        {
            var bytes = Encoding.UTF8.GetBytes(msg.ToString());
            return new ReadOnlyMemory<byte>(bytes);
        }

        public IrcMessage Read(ReadOnlySpan<byte> data)
        {
            var response = new IrcMessage();

            if (GetSection(ref data) == IrcTokenType.TagIndicator)
            {
                response.Tags = ReadTags(ref data);
            }

            response.Prefix = new IrcPrefix(ReadPrefix(ref data));
            response.CommandRaw = ReadCommand(ref data);
            response.Command = EnumHelper.GetValueFromEnumMember<IrcCommand>(response.CommandRaw);
            response.Parameters = ReadParameters(ref data);

            return response;
        }

        private Dictionary<string, string> ReadTags(ref ReadOnlySpan<byte> remaining)
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

        private string ReadPrefix(ref ReadOnlySpan<byte> remaining)
        {
            for (int i = 1; i < remaining.Length; i++)
            {
                var c = remaining[i];
                if (c == (byte)' ')
                {
                    var test = Encoding.UTF8.GetString(remaining);
                    var result = Encoding.UTF8.GetString(remaining[1..i]);
                    remaining = remaining[i..];
                    return result;
                }
            }
            throw new SerializationException("Irc message prefix was not found.");
        }

        private string ReadCommand(ref ReadOnlySpan<byte> remaining)
        {
            for (int i = 1; i < remaining.Length; i++)
            {
                var c = remaining[i];
                if (c == (byte)'#' || c == (byte)':')
                {
                    var test = Encoding.UTF8.GetString(remaining);
                    var result = Encoding.UTF8.GetString(remaining[1..(i - 1)]);
                    remaining = remaining[(i - 1)..];
                    return result;
                }
            }
            return Encoding.UTF8.GetString(remaining).Trim();
        }

        private string ReadParameters(ref ReadOnlySpan<byte> remaining)
        {
            return Encoding.UTF8.GetString(remaining).Trim();
        }

        private IrcTokenType GetSection(ref ReadOnlySpan<byte> remaining)
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
            switch (c)
            {
                case (byte)'=':
                    return IrcTokenType.TagKeyValueSeparator;
                case (byte)';':
                    return IrcTokenType.TagKeyValueEnd;
                case (byte)' ':
                    return IrcTokenType.TagEnd;
                default:
                    return IrcTokenType.None;
            }
        }
    }
}

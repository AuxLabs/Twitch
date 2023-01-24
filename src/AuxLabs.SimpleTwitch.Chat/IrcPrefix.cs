using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public struct IrcPrefix
    {
        private readonly string _value;

        public string Nickname { get; }
        public string Username { get; }
        public string Host { get; }

        public IrcPrefix(string prefix)
        {
            _value = prefix;
            Nickname = null;
            Username = null;
            Host = null;

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                if (!prefix.Contains('!') && !prefix.Contains('@'))
                {
                    Host = prefix[1..];
                    return;
                }

                var split = prefix.Split(':', '!', '@');
                Nickname = split.ElementAtOrDefault(0);
                Username = split.ElementAtOrDefault(1);
                Host = split.ElementAtOrDefault(2);
            }
        }

        public override string ToString()
            => _value;
    }
}

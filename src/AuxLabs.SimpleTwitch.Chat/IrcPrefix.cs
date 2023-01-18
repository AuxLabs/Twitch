namespace AuxLabs.SimpleTwitch.Chat
{
    public struct IrcPrefix
    {
        private readonly string _value;

        public string Nickname { get; init; } = default;
        public string Username { get; init; } = default;
        public string Host { get; init; } = default;

        public IrcPrefix(string prefix)
        {
            _value = prefix;
            if (!string.IsNullOrWhiteSpace(prefix))
            {
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

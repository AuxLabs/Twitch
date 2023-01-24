namespace AuxLabs.SimpleTwitch.Chat
{
    public struct Badge
    {
        public string Name { get; }
        public string Version { get; }

        public Badge(string name, string version = "1") 
            => (Name, Version) = (name, version);

        public override string ToString()
            => $"{Name}/{Version}";

        public static void Parse(string value, out Badge badge)
        {
            var info = value.Split('/');
            var name = info[0];
            badge = new Badge(name, info[1]);
        }

        public static bool TryParseMany(string value, out IReadOnlyCollection<Badge> badges)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                badges = null;
                return false;
            }

            var response = new List<Badge>();
            var badgeArr = value.Split(',');
            foreach (var item in badgeArr)
            {
                Parse(item, out var badge);
                response.Add(badge);
            }

            badges = response.AsReadOnly();
            return true;
        }
    }
}

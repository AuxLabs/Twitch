namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public struct Badge
    {
        public string Name { get; }
        public int Version { get; }

        public Badge(string name, int version = 1) 
            => (Name, Version) = (name, version);

        public static void Parse(string value, out Badge badge)
        {
            var info = value.Split('/');
            var name = info[0];
            int.TryParse(info[1], out var version);
            badge = new Badge(name, version);
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

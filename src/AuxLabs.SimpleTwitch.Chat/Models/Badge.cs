namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public struct Badge
    {
        public string Name { get; }
        public int Version { get; }

        public Badge(string name, int version = 1) 
            => (Name, Version) = (name, version);
    }
}

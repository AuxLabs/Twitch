namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public struct EmotePosition
    {
        public string Name { get; }
        public int StartIndex { get; }
        public int EndIndex { get; }

        public EmotePosition(string name, int start, int end)
            => (Name, StartIndex, EndIndex) = (name, start, end);
    }
}

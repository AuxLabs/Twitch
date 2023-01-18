namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public struct EmotePosition
    {
        public string Id { get; init; }
        public int StartIndex { get; init; }
        public int EndIndex { get; init; }

        public EmotePosition(string name, int start, int end)
            => (Id, StartIndex, EndIndex) = (name, start, end);
    }
}

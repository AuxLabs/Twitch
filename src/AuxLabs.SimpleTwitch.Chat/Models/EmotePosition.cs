namespace AuxLabs.SimpleTwitch.Chat
{
    public struct EmotePosition
    {
        /// <summary>
        /// An ID that uniquely identifies this emote
        /// </summary>
        public string Id { get; init; }
        /// <summary>
        /// A collection of positions this emote appears in a message
        /// </summary>
        public IReadOnlyCollection<Range> Ranges { get; init; }

        public EmotePosition(string name, IReadOnlyCollection<Range> ranges)
            => (Id, Ranges) = (name, ranges);

        public override string ToString()
            => $"{Id}:{string.Join(',', Ranges.Select(x => $"{x.Start.Value}-{x.End.Value}"))}";

        public static void Parse(string value, out EmotePosition emote)
        {
            var info = value.Split(':');
            var id = info[0];
            var positions = info[1].Split(',');

            var ranges = new List<Range>();
            foreach (var item in positions)
            {
                var position = item.Split('-');
                int start = int.Parse(position[0]);
                int end = int.Parse(position[1]);
                ranges.Add(new Range(start, end));
            }

            emote = new EmotePosition
            {
                Id = id,
                Ranges = ranges.AsReadOnly()
            };
        }

        public static bool TryParseMany(string value, out IReadOnlyCollection<EmotePosition> emotes)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                emotes = null;
                return false;
            }

            var response = new List<EmotePosition>();
            var emoteArr = value.Split('/');
            foreach (var item in emoteArr)
            {
                Parse(item, out var emote);
                response.Add(emote);
            }

            emotes = response.AsReadOnly();
            return true;
        }
    }
}

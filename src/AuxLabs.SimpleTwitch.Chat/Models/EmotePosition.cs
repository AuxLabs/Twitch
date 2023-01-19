namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public struct EmotePosition
    {
        public string Id { get; init; }
        public IReadOnlyCollection<(int Start, int End)> Indices { get; init; }

        public EmotePosition(string name, IReadOnlyCollection<(int, int)> indices)
            => (Id, Indices) = (name, indices);

        public override string ToString()
            => $"{Id}:{Indices.Select(x => $"{x.Start}-{x.End}")}";

        public static void Parse(string value, out EmotePosition emote)
        {
            var info = value.Split(':');
            var id = info[0];
            var positions = info[1].Split(',');

            var indices = new List<(int, int)>();
            foreach (var item in positions)
            {
                var position = item.Split('-');
                int start = int.Parse(position[0]);
                int end = int.Parse(position[1]);
                indices.Add((start, end));
            }

            emote = new EmotePosition
            {
                Id = id,
                Indices = indices.AsReadOnly()
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

using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AuxLabs.SimpleTwitch.Chat
{
    public readonly struct EmotePosition
    {
        /// <summary> An ID that uniquely identifies this emote </summary>
        public string Id { get; }

        /// <summary> The position of this emote in a message </summary>
        public Range Range { get; }

        public EmotePosition(string id, Range range)
            => (Id, Range) = (id, range);

        public override string ToString()
            => $"{Id}:{Range.Start.Value}-{Range.End.Value}";

        public static void Parse(string id, string range, out EmotePosition emote)
        {
            var position = range.Split('-');
            int start = int.Parse(position[0]);
            int end = int.Parse(position[1]);
            emote = new EmotePosition(id, new Range(start, end + 1));
        }

        public static bool TryParseMany(string value, out IReadOnlyCollection<EmotePosition> emotes)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                emotes = null;
                return false;
            }

            var response = new List<EmotePosition>();
            foreach (var emote in value.Split('/')) // Loop through emote ids
            {
                var emoteSplit = emote.Split(':');
                var emoteId = emoteSplit[0];

                foreach (var range in emoteSplit[1].Split(',')) // Loop through ranges in emote
                {
                    Parse(emoteId, range, out var result);
                    response.Add(result);
                }
            }

            emotes = response.ToImmutableArray();
            return true;
        }
    }
}

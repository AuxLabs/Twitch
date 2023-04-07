// https://github.com/discord-net/Discord.Net/blob/75ae48830e256086be58e25e1534358572d9dd7a/src/Discord.Net.Core/Utils/Paging/Page.cs

using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AuxLabs.Twitch
{
    internal class Page<T> : IReadOnlyCollection<T>
    {
        private readonly IReadOnlyCollection<T> _items;
        public int Index { get; }

        public Page(PageInfo info, IEnumerable<T> source)
        {
            Index = info.Page;
            _items = source.ToImmutableArray();
        }

        int IReadOnlyCollection<T>.Count => _items.Count;
        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => _items.GetEnumerator();
    }
}

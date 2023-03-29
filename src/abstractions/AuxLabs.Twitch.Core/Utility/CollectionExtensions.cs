using System;
using System.Collections;
using System.Collections.Generic;

namespace AuxLabs.Twitch
{
    internal static class CollectionExtensions
    {
        public static IReadOnlyCollection<TValue> ToReadOnlyCollection<TValue>(this ICollection<TValue> source)
            => new CollectionWrapper<TValue>(source, () => source.Count);
        public static IReadOnlyCollection<TValue> ToReadOnlyCollection<TKey, TValue>(this IDictionary<TKey, TValue> source)
            => new CollectionWrapper<TValue>(source.Values, () => source.Count);
        public static IReadOnlyCollection<TValue> ToReadOnlyCollection<TValue, TSource>(this IEnumerable<TValue> query, IReadOnlyCollection<TSource> source)
            => new CollectionWrapper<TValue>(query, () => source.Count);
        public static IReadOnlyCollection<TValue> ToReadOnlyCollection<TValue>(this IEnumerable<TValue> query, Func<int> countFunc)
            => new CollectionWrapper<TValue>(query, countFunc);
    }

    internal struct CollectionWrapper<TValue> : IReadOnlyCollection<TValue>
    {
        private readonly IEnumerable<TValue> _query;
        private readonly Func<int> _countFunc;

        public int Count => _countFunc();

        public CollectionWrapper(IEnumerable<TValue> query, Func<int> countFunc)
        {
            _query = query;
            _countFunc = countFunc;
        }

        public IEnumerator<TValue> GetEnumerator() => _query.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _query.GetEnumerator();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch
{
    public abstract class QueryMap : QueryMap<string> { }       // QueryMap defaults to string values
    public abstract class QueryMap<T> : IQueryMap<T>
    {
        private IDictionary<string, T> _map = null;

        public abstract IDictionary<string, T> CreateQueryMap();
        private IDictionary<string, T> Map
        {
            get
            {
                if (_map == null)
                    _map = CreateQueryMap();
                return _map;
            }
        }

        // IDictionary
        T IDictionary<string, T>.this[string key] { get => Map[key]; set => throw new NotSupportedException(); }
        ICollection<string> IDictionary<string, T>.Keys => Map.Keys;
        ICollection<T> IDictionary<string, T>.Values => Map.Values;

        void IDictionary<string, T>.Add(string key, T value) => throw new NotSupportedException();
        bool IDictionary<string, T>.ContainsKey(string key) => Map.ContainsKey(key);
        bool IDictionary<string, T>.Remove(string key) => throw new NotSupportedException();
        bool IDictionary<string, T>.TryGetValue(string key, out T value) => Map.TryGetValue(key, out value);

        // ICollection
        int ICollection<KeyValuePair<string, T>>.Count => Map.Count;
        bool ICollection<KeyValuePair<string, T>>.IsReadOnly => true;
        void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item) => throw new NotSupportedException();
        bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item) => throw new NotSupportedException();
        void ICollection<KeyValuePair<string, T>>.Clear() => throw new NotSupportedException();
        bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item) => Map.Contains(item);
        void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex) => Map.CopyTo(array, arrayIndex);

        // IEnumerable
        IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator() => Map.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Map.GetEnumerator();
    }

    // Used to hide IDictionary extension methods
    internal interface IQueryMap<T> : IDictionary<string, T> { }
}

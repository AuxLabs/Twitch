// https://github.com/discord-net/Discord.Net/blob/75ae48830e256086be58e25e1534358572d9dd7a/src/Discord.Net.Core/Utils/Cacheable.cs

using System;
using System.Threading.Tasks;

namespace AuxLabs.Twitch
{
    public struct Cacheable<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : IEquatable<TId>
    {
        public bool HasValue { get; }
        public TId Id { get; }
        public TEntity Value { get; }
        private Func<Task<TEntity>> DownloadFunc { get; }

        internal Cacheable(TEntity value, TId id, bool hasValue, Func<Task<TEntity>> downloadFunc)
        {
            Value = value;
            Id = id;
            HasValue = hasValue;
            DownloadFunc = downloadFunc;
        }

        public async Task<TEntity> DownloadAsync()
        {
            return await DownloadFunc().ConfigureAwait(false);
        }

        public async Task<TEntity> GetOrDownloadAsync() => HasValue ? Value : await DownloadAsync().ConfigureAwait(false);
    }
}

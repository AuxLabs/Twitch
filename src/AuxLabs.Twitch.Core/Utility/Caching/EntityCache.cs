// https://github.com/discord-net/Discord.Net/blob/1b64d19c845cb7c612a1c52288c8b44cff605105/src/Discord.Net.WebSocket/Entities/Messages/MessageCache.cs

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AuxLabs.Twitch
{
    internal class EntityCache<TId, TEntity>
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        private readonly ConcurrentDictionary<TId, TEntity> _entities;
        private readonly ConcurrentQueue<TId> _orderedEntities;
        private readonly int _size;

        public IReadOnlyCollection<TEntity> Entities => _entities.ToReadOnlyCollection();

        public EntityCache(int size)
        {
            _size = size;
            _entities= new ConcurrentDictionary<TId, TEntity>(ConcurrentHashSet.DefaultConcurrencyLevel, (int)(_size * 1.05));
            _orderedEntities = new ConcurrentQueue<TId>();
        }

        public void Add(TEntity entity)
        {
            if (_entities.TryAdd(entity.Id, entity))
            {
                _orderedEntities.Enqueue(entity.Id);

                while (_orderedEntities.Count > _size && _orderedEntities.TryDequeue(out var entityId))
                    _entities.TryRemove(entityId, out _);
            }
        }

        public TEntity Remove(TId id)
        {
            _entities.TryRemove(id, out var entity);
            return entity;
        }

        public IReadOnlyCollection<TEntity> RemoveAll()
        {
            var entities = _entities.Values.ToReadOnlyCollection();
            _entities.Clear();
            _orderedEntities.Clear();
            return entities;
        }

        public TEntity Get(TId id)
        {
            if (id == null) return null;
            if (_entities.TryGetValue(id, out var result))
                return result;
            return null;
        }

        public IReadOnlyCollection<TEntity> GetMany(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (count == 0) return ImmutableArray<TEntity>.Empty;

            var entityIds = _orderedEntities.Take(count);
            return entityIds.Select(x =>
            {
                if (_entities.TryGetValue(x, out var entity))
                    return entity;
                return null;
            }).Where(x => x != null)
            .Take(count)
            .ToImmutableArray();
        }
    }
}

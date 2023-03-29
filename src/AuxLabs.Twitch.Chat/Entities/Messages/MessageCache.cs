// https://github.com/discord-net/Discord.Net/blob/1b64d19c845cb7c612a1c52288c8b44cff605105/src/Discord.Net.WebSocket/Entities/Messages/MessageCache.cs

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AuxLabs.Twitch.Chat
{
    internal class MessageCache
    {
        private readonly ConcurrentDictionary<string, ChatMessage> _messages;
        private readonly ConcurrentQueue<string> _orderedMessages;
        private readonly int _size;

        public IReadOnlyCollection<ChatMessage> Messages => _messages.ToReadOnlyCollection();

        public MessageCache(int size)
        {
            _size = size;
            _messages= new ConcurrentDictionary<string, ChatMessage>(ConcurrentHashSet.DefaultConcurrencyLevel, (int)(_size * 1.05));
            _orderedMessages = new ConcurrentQueue<string>();
        }

        public void Add(ChatMessage message)
        {
            if (_messages.TryAdd(message.Id, message))
            {
                _orderedMessages.Enqueue(message.Id);

                while (_orderedMessages.Count > _size && _orderedMessages.TryDequeue(out var msgId))
                    _messages.TryRemove(msgId, out _);
            }
        }

        public ChatMessage Remove(string id)
        {
            _messages.TryRemove(id, out var msg);
            return msg;
        }

        public IReadOnlyCollection<ChatMessage> RemoveAll()
        {
            var messages = _messages.Values.ToReadOnlyCollection();
            _messages.Clear();
            _orderedMessages.Clear();
            return messages;
        }

        public ChatMessage Get(string id)
        {
            if (_messages.TryGetValue(id, out var result))
                return result;
            return null;
        }

        public IReadOnlyCollection<ChatMessage> GetMany(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (count == 0) return ImmutableArray<ChatMessage>.Empty;

            var messageIds = _orderedMessages.Take(count);
            return messageIds.Select(x =>
            {
                if (_messages.TryGetValue(x, out var msg))
                    return msg;
                return null;
            }).Where(x => x != null)
            .Take(count)
            .ToImmutableArray();
        }
    }
}

using AuxLabs.Twitch;
using System;

namespace AuxLabs.Twitch.Chat.Entities
{
    public abstract class ChatEntity<T> : IEquatable<ChatEntity<T>>, IEntity<T>
    {
        /// <summary> An ID that uniquely identifies the entity. </summary>
        public T Id { get; }
        internal TwitchChatClient Twitch { get; }

        internal ChatEntity(TwitchChatClient twitch, T id)
            => (Twitch, Id) = (twitch, id);

        public override string ToString()
            => Id.ToString();
        public bool Equals(ChatEntity<T> other)
            => Id.Equals(other.Id);
        public override bool Equals(object obj)
            => Equals(obj as ChatEntity<T>);
        public override int GetHashCode()
            => HashCode.Combine(Id);
    }

    public abstract class ChatNamedEntity : IEquatable<ChatNamedEntity>
    {
        /// <summary> A name that uniquely identifies the entity. </summary>
        public string Name { get; }
        internal TwitchChatClient Twitch { get; }

        internal ChatNamedEntity(TwitchChatClient twitch, string name)
            => (Twitch, Name) = (twitch, name);

        public bool Equals(ChatNamedEntity other)
            => Name.Equals(other.Name);
        public override bool Equals(object obj)
            => Equals(obj as ChatNamedEntity);
        public override int GetHashCode()
            => HashCode.Combine(Name);
    }
}
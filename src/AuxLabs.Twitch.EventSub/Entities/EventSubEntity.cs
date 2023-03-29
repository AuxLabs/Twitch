using System;

namespace AuxLabs.Twitch.EventSub
{
    public abstract class EventSubEntity<T>
        where T : IEquatable<T>
    {
        /// <summary> An ID that uniquely identifies the entity. </summary>
        public T Id { get; }
        internal TwitchEventSubClient Twitch { get; }

        internal EventSubEntity(TwitchEventSubClient twitch, T id)
            => (Twitch, Id) = (twitch, id);
    }
}

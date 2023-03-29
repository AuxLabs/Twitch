using System;

namespace AuxLabs.Twitch.Rest
{
    public abstract class RestEntity<T>
        where T : IEquatable<T>
    {
        /// <summary> An ID that uniquely identifies the entity. </summary>
        public T Id { get; }
        internal TwitchRestClient Twitch { get; }

        internal RestEntity(TwitchRestClient twitch, T id)
            => (Twitch, Id) = (twitch, id);
    }
}

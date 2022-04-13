namespace AuxLabs.Twitch.Rest.Entities
{
    public abstract record class RestEntity<T>
    {
        internal TwitchRestClient Twitch { get; }
        public T Id { get; }

        internal RestEntity(TwitchRestClient twitch, T id)
            => (Twitch, Id) = (twitch, id);
    }
}

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestPartialUser : RestEntity<string>
    {
        /// <summary> User’s login name </summary>
        public string Name { get; private set; }

        public RestPartialUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestPartialUser Create(TwitchRestClient twitch, string id, string name)
        {
            var entity = new RestPartialUser(twitch, id);
            entity.Update(name);
            return entity;
        }
        internal virtual void Update(string name)
        {
            Name = name;
        }

        public override string ToString() => Name + $"({Id})";
    }
}

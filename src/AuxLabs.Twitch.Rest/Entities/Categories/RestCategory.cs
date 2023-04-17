using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestCategory : RestEntity<string>
    {
        /// <summary>  </summary>
        public string Name { get; private set; }

        /// <summary>  </summary>
        public string BoxArtUrl { get; private set; }

        public RestCategory(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestCategory Create(TwitchRestClient twitch, Category model)
        {
            var entity = new RestCategory(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Category model)
        {
            Name = model.Name;
            BoxArtUrl = model.BoxArtUrl;
        }
    }
}

using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestGame : RestCategory
    {
        /// <summary>  </summary>
        public string IgdbId { get; private set; }

        public RestGame(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestGame Create(TwitchRestClient twitch, Game model)
        {
            var entity = new RestGame(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Game model)
        {
            base.Update(model);
            IgdbId = model.IgdbId;
        }
    }
}

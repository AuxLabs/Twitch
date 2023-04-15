using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestBadge : RestEntity<string>
    {
        /// <summary>  </summary>
        public string Title { get; private set; }

        /// <summary>  </summary>
        public string Description { get; private set; }

        /// <summary>  </summary>
        public string ClickAction { get; private set; }

        /// <summary>  </summary>
        public string ClickUrl { get; private set; }

        /// <summary>  </summary>
        public TwitchImage Images { get; private set; }

        internal RestBadge(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestBadge Create(TwitchRestClient twitch, Badge model)
        {
            var entity = new RestBadge(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Badge model)
        {
            Title = model.Title;
            Description = model.Description;
            ClickAction = model.ClickAction;
            ClickUrl = model.ClickUrl;
            Images = new TwitchImage
            {
                SmallImageUrl = model.SmallImageUrl,
                MediumImageUrl = model.MediumImageUrl,
                LargeImageUrl = model.LargeImageUrl
            };
        }
    }
}

using AuxLabs.Twitch.Rest.Models;
using System;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestPartialTeam : RestEntity<string>
    {
        /// <summary>  </summary>
        public string Name { get; private set; }

        /// <summary>  </summary>
        public string DisplayName { get; private set; }

        /// <summary>  </summary>
        public string Description { get; private set; }

        /// <summary>  </summary>
        public string BackgroundImageUrl { get; private set; }

        /// <summary>  </summary>
        public string BannerImageUrl { get; private set; }

        /// <summary>  </summary>
        public string ThumbnailUrl { get; private set; }

        /// <summary>  </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>  </summary>
        public DateTime UpdatedAt { get; private set; }

        public RestPartialTeam(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestPartialTeam Create(TwitchRestClient twitch, PartialTeam model)
        {
            var entity = new RestPartialTeam(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(PartialTeam model)
        {
            Name = model.Name;
            DisplayName = model.DisplayName;
            Description = model.Description;
            BackgroundImageUrl = model.BackgroundImageUrl;
            BannerImageUrl = model.BannerUrl;
            ThumbnailUrl = model.ThumbnailUrl;
            CreatedAt = model.CreatedAt;
            UpdatedAt = model.UpdatedAt;
        }
    }
}

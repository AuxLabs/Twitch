using AuxLabs.Twitch.Rest.Models;
using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestGlobalEmote : RestEntity<string>
    {
        /// <summary>  </summary>
        public string Name { get; private set; }

        /// <summary>  </summary>
        public TwitchImage Images { get; private set; }

        /// <summary>  </summary>
        public IReadOnlyCollection<EmoteFormat> Formats { get; private set; }

        /// <summary>  </summary>
        public IReadOnlyCollection<EmoteScale> Scales { get; private set; }

        /// <summary>  </summary>
        public IReadOnlyCollection<EmoteTheme> Themes { get; private set; }

        public RestGlobalEmote(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestGlobalEmote Create(TwitchRestClient twitch, GlobalEmote model)
        {
            var entity = new RestGlobalEmote(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(GlobalEmote model)
        {
            Name = model.Name;
            Images = model.Images;
            Formats = model.Formats;
            Scales = model.Scales;
            Themes = model.Themes;
        }
    }
}

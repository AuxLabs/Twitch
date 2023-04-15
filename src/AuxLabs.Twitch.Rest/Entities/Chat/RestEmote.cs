using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestEmote : RestGlobalEmote
    {
        /// <summary>  </summary>
        public string Tier { get; private set; }

        /// <summary>  </summary>
        public EmoteType Type { get; private set; }

        /// <summary>  </summary>
        public string EmoteSetId { get; private set; }

        /// <summary>  </summary>
        public string BroadcasterId { get; private set; }

        internal RestEmote(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestEmote Create(TwitchRestClient twitch, Emote model)
        {
            var entity = new RestEmote(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Emote model)
        {
            base.Update(model);
            Tier = model.Tier;
            Type = model.Type;
            EmoteSetId = model.EmoteSetId;
            BroadcasterId = model.BroadcasterId;
        }
    }
}

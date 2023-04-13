using AuxLabs.Twitch.Rest.Models;
using System;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestMarker : RestEntity<string>
    {
        /// <summary>  </summary>
        public string Description { get; set; }

        /// <summary>  </summary>
        public TimeSpan Position { get; set; }

        /// <summary>  </summary>
        public DateTime CreatedAt { get; set; }

        internal RestMarker(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestMarker Create(TwitchRestClient twitch, BroadcastMarker model)
        {
            var entity = new RestMarker(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(BroadcastMarker model)
        {
            Description = model.Description;
            Position = TimeSpan.FromSeconds(model.PositionSeconds);
            CreatedAt = model.CreatedAt;
        }

        public override string ToString() => Id.ToString();
    }
}

using AuxLabs.Twitch.Rest.Models;
using System.Drawing;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestSimpleChatUser : RestSimpleUser
    {
        /// <summary>  </summary>
        public Color Color { get; private set; }

        public RestSimpleChatUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestSimpleChatUser Create(TwitchRestClient twitch, SimpleChatUser model)
        {
            var entity = new RestSimpleChatUser(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(SimpleChatUser model)
        {
            base.Update(model);
            Color = model.Color;
        }
    }
}

using AuxLabs.Twitch.Rest.Models;
using System.Drawing;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestChatUser : RestSimpleUser, IChatUser
    {
        /// <summary>  </summary>
        public Color? Color { get; private set; }

        public RestChatUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestChatUser Create(TwitchRestClient twitch, SimpleChatUser model)
        {
            var entity = new RestChatUser(twitch, model.Id);
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

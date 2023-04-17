using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestBitsUser : RestSimpleUser
    {
        /// <summary>  </summary>
        public int Rank { get; private set; }

        /// <summary>  </summary>
        public int TotalBits { get; private set; }

        public RestBitsUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestBitsUser Create(TwitchRestClient twitch, BitsUser model)
        {
            var entity = new RestBitsUser(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(BitsUser model)
        {
            base.Update(model.UserName, model.UserDisplayName);
            Rank = model.Rank;
            TotalBits = model.TotalBits;
        }
    }
}

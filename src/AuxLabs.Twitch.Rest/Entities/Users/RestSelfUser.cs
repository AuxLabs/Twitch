using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestSelfUser : RestUser
    {
        /// <summary> Date when the user was created </summary>
        public string Email { get; private set; }

        internal RestSelfUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal new static RestSelfUser Create(TwitchRestClient twitch, User model)
        {
            var entity = new RestSelfUser(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal override void Update(User model)
        {
            base.Update(model);
            Email = model.Email;
        }

        public override async Task UpdateAsync()
        {
            var args = new GetUsersArgs(GetUsersMode.Id, Id);
            var self = await Twitch.API.GetUsersAsync(args);
            Update(self.Data.SingleOrDefault());
        }

        public async Task ModifyAsync(string description)
        {
            var self = await Twitch.API.PutUserAsync(description);
            Update(self.Data.SingleOrDefault());
        }
    }
}

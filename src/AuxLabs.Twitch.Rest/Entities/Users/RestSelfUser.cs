using AuxLabs.Twitch.Rest;
using System.Linq;
using System.Threading.Tasks;
using Model = AuxLabs.Twitch.Rest.User;

namespace AuxLabs.Twitch.Rest
{
    public class RestSelfUser : RestUser
    {
        /// <summary> Date when the user was created </summary>
        public string Email { get; private set; }

        internal RestSelfUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal new static RestSelfUser Create(TwitchRestClient twitch, Model model)
        {
            var entity = new RestSelfUser(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Model model)
        {
            base.Update(model);
            this.Email = model.Email!.ToString();
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

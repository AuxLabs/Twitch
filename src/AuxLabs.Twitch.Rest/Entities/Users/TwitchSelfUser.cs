using Model = AuxLabs.SimpleTwitch.Rest.Models.User;

namespace AuxLabs.Twitch.Rest.Entities
{
    public record class TwitchSelfUser : TwitchUser
    {
        /// <summary>
        /// Date when the user was created
        /// </summary>
        public string Email { get; internal set; } = default!;

        internal TwitchSelfUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal new static TwitchSelfUser Create(TwitchRestClient twitch, Model model)
        {
            var entity = new TwitchSelfUser(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Model model)
        {
            base.Update(model);
            this.Email = model.Email!.ToString();
        }

        public override Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

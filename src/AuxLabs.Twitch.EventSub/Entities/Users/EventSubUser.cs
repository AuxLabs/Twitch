using UserUpdated = AuxLabs.Twitch.EventSub.Models.UserUpdatedEventArgs;

namespace AuxLabs.Twitch.EventSub.Entities
{
    public class EventSubUser : EventSubSimpleUser
    {
        /// <summary>  </summary>
        public string Description { get; private set; }

        /// <summary>  </summary>
        public string Email { get; private set; }

        /// <summary>  </summary>
        public bool IsEmailVerified { get; private set; }

        public EventSubUser(TwitchEventSubClient twitch, string id)
            : base(twitch, id) { }

        internal static EventSubUser Create(TwitchEventSubClient twitch, UserUpdated model)
        {
            var entity = new EventSubUser(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(UserUpdated model)
        {
            base.Update(model);
            Description = model.Description;
            Email = model.UserEmail;
            IsEmailVerified = model.IsEmailVerified;
        }
    }
}

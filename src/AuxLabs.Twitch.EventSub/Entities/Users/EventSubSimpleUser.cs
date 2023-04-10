using Ban = AuxLabs.Twitch.EventSub.Models.BanEventArgs;
using UserUpdated = AuxLabs.Twitch.EventSub.Models.UserUpdatedEventArgs;
using BroadcastEnded = AuxLabs.Twitch.EventSub.Models.BroadcastEndedEventArgs;

namespace AuxLabs.Twitch.EventSub.Entities
{
    internal enum ModelUserType
    {
        User,
        Moderator,
        Broadcaster
    }

    public class EventSubSimpleUser : EventSubEntity<string>, ISimpleUser
    {
        /// <summary>  </summary>
        public string Name { get; private set; }

        /// <summary>  </summary>
        public string DisplayName { get; private set; }

        public EventSubSimpleUser(TwitchEventSubClient twitch, string id)
            : base(twitch, id) { }

        internal static EventSubSimpleUser Create(TwitchEventSubClient twitch, Ban model, ModelUserType type)
        {
            var entity = new EventSubSimpleUser(twitch, model.UserId);
            entity.Update(model, type);
            return entity;
        }
        internal virtual void Update(Ban model, ModelUserType type)
        {
            switch (type)
            {
                case ModelUserType.User:
                    Name = model.UserName;
                    DisplayName = model.UserDisplayName;
                    break;

                case ModelUserType.Moderator:
                    Name = model.ModeratorName;
                    DisplayName = model.ModeratorDisplayName;
                    break;

                case ModelUserType.Broadcaster:
                    Name = model.BroadcasterName;
                    DisplayName = model.BroadcasterDisplayName;
                    break;
            }
        }

        internal static EventSubSimpleUser Create(TwitchEventSubClient twitch, BroadcastEnded model)
        {
            var entity = new EventSubSimpleUser(twitch, model.BroadcasterId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(BroadcastEnded model)
        {
            Name = model.BroadcasterName;
            DisplayName = model.BroadcasterDisplayName;
        }

        internal virtual void Update(UserUpdated model)
        {
            Name = model.UserName;
            DisplayName = model.UserDisplayName;
        }
    }
}

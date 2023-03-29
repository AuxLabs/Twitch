using BanArgs = AuxLabs.Twitch.EventSub.Models.BanEventArgs;

namespace AuxLabs.Twitch.EventSub.Entities
{
    internal enum BanUserType
    {
        User,
        Moderator,
        Broadcaster
    }

    public class EventSubUser : EventSubEntity<string>
    {
        /// <summary>  </summary>
        public string Name { get; private set; }

        /// <summary>  </summary>
        public string DisplayName { get; private set; }

        public EventSubUser(TwitchEventSubClient twitch, string id)
            : base(twitch, id) { }

        internal static EventSubUser Create(TwitchEventSubClient twitch, BanArgs model, BanUserType type)
        {
            var entity = new EventSubUser(twitch, model.UserId);
            entity.Update(model, type);
            return entity;
        }
        internal virtual void Update(BanArgs model, BanUserType type)
        {
            switch (type)
            {
                case BanUserType.User:
                    Name = model.UserName;
                    DisplayName = model.UserDisplayName;
                    break;

                case BanUserType.Moderator:
                    Name = model.ModeratorName;
                    DisplayName = model.ModeratorDisplayName;
                    break;

                case BanUserType.Broadcaster:
                    Name = model.BroadcasterName;
                    DisplayName = model.BroadcasterDisplayName;
                    break;
            }
        }
    }
}

using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestSimpleUser : RestPartialUser
    {
        /// <summary> User’s display name </summary>
        public string DisplayName { get; private set; }

        public RestSimpleUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal virtual void Update(string userName, string displayName)
        {
            base.Update(userName);
            DisplayName = displayName;
        }

        internal static RestSimpleUser Create(TwitchRestClient twitch, Broadcast model)
        {
            var entity = new RestSimpleUser(twitch, model.UserId);
            entity.Update(model.UserName, model.UserDisplayName);
            return entity;
        }
        internal static RestSimpleUser Create(TwitchRestClient twitch, SimpleUser model)
        {
            var entity = new RestSimpleUser(twitch, model.Id);
            entity.Update(model.Name, model.DisplayName);
            return entity;
        }
        internal static RestSimpleUser Create(TwitchRestClient twitch, Subscription model)
        {
            var entity = new RestSimpleUser(twitch, model.UserId);
            entity.Update(model.UserName, model.UserDisplayName);
            return entity;
        }
        internal static RestSimpleUser Create(TwitchRestClient twitch, TeamUser model)
        {
            var entity = new RestSimpleUser(twitch, model.Id);
            entity.Update(model.Name, model.DisplayName);
            return entity;
        }
        internal static RestSimpleUser Create(TwitchRestClient twitch, ChannelTeam model)
        {
            var entity = new RestSimpleUser(twitch, model.BroadcasterId);
            entity.Update(model.BroadcasterName, model.BroadcasterDisplayName);
            return entity;
        }
        internal static RestSimpleUser Create(TwitchRestClient twitch, Video model)
        {
            var entity = new RestSimpleUser(twitch, model.UserId);
            entity.Update(model.UserName, model.UserDisplayName);
            return entity;
        }

        internal static RestSimpleUser Create(TwitchRestClient twitch, ExtensionTransaction model, bool isBroadcaster)
        {
            RestSimpleUser entity;
            if (isBroadcaster)
            {
                entity = new RestSimpleUser(twitch, model.BroadcasterId);
                entity.Update(model.BroadcasterName, model.BroadcasterDisplayName);
            } else
            {
                entity = new RestSimpleUser(twitch, model.UserId);
                entity.Update(model.UserName, model.UserDisplayName);
            }
            return entity;
        }
        internal static RestSimpleUser Create(TwitchRestClient twitch, SimpleSubscription model, bool isBroadcaster)
        {
            RestSimpleUser entity;
            if (isBroadcaster)
            {
                entity = new RestSimpleUser(twitch, model.BroadcasterId);
                entity.Update(model.BroadcasterName, model.BroadcasterDisplayName);
            }
            else
            {
                entity = new RestSimpleUser(twitch, model.GifterId);
                entity.Update(model.GifterName, model.GifterDisplayName);
            }
            return entity;
        }

        public override string ToString() => DisplayName ?? Name + $"({Id})";
    }
}

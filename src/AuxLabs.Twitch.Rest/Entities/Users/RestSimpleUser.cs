using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestSimpleUser : RestPartialUser
    {
        /// <summary> User’s display name </summary>
        public string DisplayName { get; private set; }

        public RestSimpleUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestSimpleUser Create(TwitchRestClient twitch, Broadcast model)
        {
            var entity = new RestSimpleUser(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Broadcast model)
        {
            base.Update(model.UserName);
            DisplayName = model.UserDisplayName;
        }

        internal static RestSimpleUser Create(TwitchRestClient twitch, SimpleUser model)
        {
            var entity = new RestSimpleUser(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(SimpleUser model)
        {
            base.Update(model.Name);
            DisplayName = model.DisplayName;
        }

        internal static RestSimpleUser Create(TwitchRestClient twitch, ExtensionTransaction model, bool isBroadcaster)
        {
            var id = isBroadcaster ? model.BroadcasterId : model.UserId;
            var entity = new RestSimpleUser(twitch, id);
            entity.Update(model, isBroadcaster);
            return entity;
        }
        internal virtual void Update(ExtensionTransaction model, bool isBroadcaster)
        {
            if (isBroadcaster)
            {
                base.Update(model.BroadcasterName);
                DisplayName = model.BroadcasterDisplayName;
            } else
            {
                base.Update(model.UserName);
                DisplayName = model.UserDisplayName;
            }
        }

        internal static RestSimpleUser Create(TwitchRestClient twitch, SimpleSubscription model, bool isBroadcaster)
        {
            var id = isBroadcaster ? model.BroadcasterId : model.GifterId;
            var entity = new RestSimpleUser(twitch, id);
            entity.Update(model, isBroadcaster);
            return entity;
        }
        internal virtual void Update(SimpleSubscription model, bool isBroadcaster)
        {
            if (isBroadcaster)
            {
                base.Update(model.BroadcasterName);
                DisplayName = model.BroadcasterDisplayName;
            }
            else
            {
                base.Update(model.GifterName);
                DisplayName = model.GifterDisplayName;
            }
        }

        internal static RestSimpleUser Create(TwitchRestClient twitch, Subscription model)
        {
            var entity = new RestSimpleUser(twitch, model.UserName);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Subscription model)
        {
            base.Update(model.UserName);
            DisplayName = model.UserDisplayName;
        }

        internal virtual void Update(Follower model)
        {
            base.Update(model.UserName);
            DisplayName = model.UserDisplayName;
        }
        internal virtual void Update(BitsUser model)
        {
            base.Update(model.UserName);
            DisplayName = model.UserDisplayName;
        }
        internal virtual void Update(Channel model)
        {
            base.Update(model.BroadcasterName);
            DisplayName = model.BroadcasterDisplayName;
        }
        internal virtual void Update(FollowedChannel model)
        {
            base.Update(model.BroadcasterName);
            DisplayName = model.BroadcasterDisplayName;
        }

        public override string ToString() => DisplayName ?? Name + $"({Id})";
    }
}

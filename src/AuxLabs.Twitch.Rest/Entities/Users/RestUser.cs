using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestUser : RestSimpleUser
    {
        /// <summary> User’s verified email address </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary> User’s channel description </summary>
        public string Description { get; private set; }

        /// <summary> Total number of views of the user’s channel </summary>
        public int ViewCount { get; private set; }

        /// <summary> URL of the user’s offline image </summary>
        public string OfflineImageUrl { get; private set; }

        /// <summary> URL of the user’s profile image </summary>
        public string ProfileImageUrl { get; private set; }

        /// <summary> User’s broadcaster type </summary>
        public BroadcasterType BroadcasterType { get; private set; }

        /// <summary> User’s type </summary>
        public UserType Type { get; private set; }

        internal RestUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestUser Create(TwitchRestClient twitch, User model)
        {
            var entity = new RestUser(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(User model)
        {
            base.Update(model);
            CreatedAt = model.CreatedAt;
            Description = model.Description;
            ViewCount = model.ViewCount;
            OfflineImageUrl = model.OfflineImageUrl;
            ProfileImageUrl = model.ProfileImageUrl;
            BroadcasterType = model.BroadcasterType;
            Type = model.Type;
        }

        public virtual async Task UpdateAsync()
        {
            var args = new GetUsersArgs(GetUsersMode.Id, Id);
            var model = await Twitch.API.GetUsersAsync(args);
            Update(model.Data.First());
        }
    }
}

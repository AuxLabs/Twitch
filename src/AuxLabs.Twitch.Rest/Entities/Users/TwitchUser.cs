using AuxLabs.SimpleTwitch.Rest.Models;
using Model = AuxLabs.SimpleTwitch.Rest.Models.User;

namespace AuxLabs.Twitch.Rest.Entities
{
    public record class TwitchUser : RestEntity<string>
    {
        /// <summary>
        /// User’s display name
        /// </summary>
        public string DisplayName { get; internal set; } = default!;

        /// <summary>
        /// User’s login name
        /// </summary>
        public string UserName { get; internal set; } = default!;

        /// <summary>
        /// User’s verified email address
        /// </summary>
        public DateTime CreatedAt { get; internal set; } = default!;

        /// <summary>
        /// User’s channel description
        /// </summary>
        public string Description { get; internal set; } = default!;

        /// <summary>
        /// Total number of views of the user’s channel
        /// </summary>
        public int ViewCount { get; internal set; } = default!;

        /// <summary>
        /// URL of the user’s offline image
        /// </summary>
        public string OfflineImageUrl { get; internal set; } = default!;

        /// <summary>
        /// URL of the user’s profile image
        /// </summary>
        public string ProfileImageUrl { get; internal set; } = default!;

        /// <summary>
        /// User’s broadcaster type
        /// </summary>
        public BroadcasterType BroadcasterType { get; internal set; } = default!;

        /// <summary>
        /// User’s type
        /// </summary>
        public UserType Type { get; internal set; } = default!;


        internal TwitchUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static TwitchUser Create(TwitchRestClient twitch, Model model)
        {
            var entity = new TwitchUser(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Model model)
        {
            this.DisplayName = model.DisplayName;
            this.UserName = model.Login;
            this.CreatedAt = model.CreatedAt;
            this.Description = model.Description;
            this.ViewCount = model.ViewCount;
            this.OfflineImageUrl = model.OfflineImageUrl;
            this.ProfileImageUrl = model.ProfileImageUrl;
            this.BroadcasterType = model.BroadcasterType;
            this.Type = model.Type;
        }

        public virtual Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

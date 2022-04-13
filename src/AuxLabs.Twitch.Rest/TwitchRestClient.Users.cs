using AuxLabs.SimpleTwitch.Rest.Models;
using AuxLabs.SimpleTwitch.Rest.Requests;
using AuxLabs.Twitch.Rest.Entities;

namespace AuxLabs.Twitch.Rest
{
    public partial class TwitchRestClient
    {
        public async Task<TwitchUser?> GetUserByNameAsync(string username)
            => (await GetUsersByNameAsync(username))?.FirstOrDefault();
        public async Task<IEnumerable<TwitchUser>?> GetUsersByNameAsync(params string[] userNames)
        {
            var response = await API.GetUsersAsync(new GetUsersParams
            {
                UserNames = userNames
            });

            return ConvertUserCollection(response?.Data);
        }

        public async Task<TwitchUser?> GetUserByIdAsync(string id)
            => (await GetUsersByIdAsync(id))?.FirstOrDefault();
        public async Task<IEnumerable<TwitchUser>?> GetUsersByIdAsync(params string[] userIds)
        {
            var response = await API.GetUsersAsync(new GetUsersParams
            {
                UserNames = userIds
            });

            return ConvertUserCollection(response?.Data);
        }

        internal IReadOnlyList<TwitchUser>? ConvertUserCollection(IEnumerable<User>? data)
        {
            if (data == null || !data.Any())
                return null;

            var users = new List<TwitchUser>();
            foreach (var user in data)
            {
                var entity = new TwitchUser(this, user.Id);
                entity.Update(user);

                users.Add(entity);
            }
            return users.AsReadOnly();
        }
    }
}

using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Requests;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public partial class TwitchRestClient
    {
        public async Task<RestSelfUser> GetMyUserAsync()
        {
            IsUserAuthorized(out var identity);
            MyUser = (await GetUserByIdAsync(identity.UserId)) as RestSelfUser;
            return MyUser;
        }

        public async Task<RestSelfUser> ModifyMyUserAsync(string description)
        {
            var response = await API.PutUserAsync(description);
            return RestSelfUser.Create(this, response.Data.First());
        }

        public async Task<RestUser> GetUserByNameAsync(string username)
            => (await GetUsersByNameAsync(username))?.SingleOrDefault();
        public async Task<IReadOnlyCollection<RestUser>> GetUsersByNameAsync(params string[] userNames)
        {
            var args = new GetUsersArgs(GetUsersMode.Name, userNames);
            var response = await API.GetUsersAsync(args);
            return response.Data.Select(x => RestUser.Create(this, x)).ToImmutableArray();
        }

        public async Task<RestUser> GetUserByIdAsync(string id)
            => (await GetUsersByIdAsync(id))?.SingleOrDefault();
        public async Task<IReadOnlyCollection<RestUser>> GetUsersByIdAsync(params string[] userIds)
        {
            var response = await API.GetUsersAsync(new GetUsersArgs
            {
                UserIds = userIds
            });

            return response.Data.Select(x => RestUser.Create(this, x)).ToImmutableArray();
        }

        // GetBlockedUsers
        // AddBlockedUser
        // RemoveBlockedUser
        // GetExtensions
        // GetActiveExtensions
        // ModifyExtensions
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Tests
{
    public static class MockApiHelper
    {
        private static Random R = new Random();

        public static async Task<IEnumerable<string>> GetRandomUsernamesAsync(this IMockApi mock, int count = 5)
        {
            var users = await mock.GetUsersAsync();
            return users.Data.OrderBy(x => R.Next()).Take(count).Select(x => x.Login);
        }

        public static async Task<IEnumerable<string>> GetRandomUserIdsAsync(this IMockApi mock, int count = 5)
        {
            var users = await mock.GetUsersAsync();
            return users.Data.OrderBy(x => R.Next()).Take(count).Select(x => x.Id);
        }
    }
}

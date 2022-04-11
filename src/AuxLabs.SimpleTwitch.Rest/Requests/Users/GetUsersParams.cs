using RestEase;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetUsersParams : IRequest
    {
        public string[] Scopes { get; } = default!;

        [Query("id")]
        public IEnumerable<string>? UserIds { get; set; }
        [Query("login")]
        public IEnumerable<string>? UserNames { get; set; }

        public GetUsersParams() { }
        public GetUsersParams(GetUsersMode mode, params string[] users)
        {
            if (mode == GetUsersMode.Id)
                UserIds = new List<string>(users);
            if (mode == GetUsersMode.Name)
                UserNames = new List<string>(users);
        }
    }

    public enum GetUsersMode
    {
        Id,
        Name
    }
}

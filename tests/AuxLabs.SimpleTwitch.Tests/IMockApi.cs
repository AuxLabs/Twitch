using AuxLabs.SimpleTwitch.Rest.Models;
using RestEase;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Tests
{
    public interface IMockApi
    {
        [Query("client_id")]
        string ClientId { get; set; }

        [Query("client_secret")]
        string ClientSecret { get; set; }

        [Get("units/categories")]
        Task<TwitchResponse<object>> GetCategoriesAsync();
        [Get("units/clients")]
        Task<TwitchResponse<Client>> GetClientsAsync();
        [Get("units/streams")]
        Task<TwitchResponse<Channel>> GetChannelsAsync();
        [Get("units/subscriptions")]
        Task<TwitchResponse<object>> GetSubscriptionsAsync();
        [Get("units/tags")]
        Task<TwitchResponse<object>> GetTagsAsync();
        [Get("units/teams")]
        Task<TwitchResponse<object>> GetTeamsAsync();
        [Get("units/users")]
        Task<TwitchResponse<User>> GetUsersAsync();
        [Get("units/videos")]
        Task<TwitchResponse<object>> GetVideosAsync();

        [Post("auth/token?grant_type=client_credentials")]
        Task<AccessToken> GetAppTokenAsync();

        [Post("auth/authorize?grant_type=user_token")]
        Task<AccessToken> GetUserTokenAsync(
            [Query("user_id")]string userId,
            [RawQueryString]string scopes);
    }

    public class Client
    {
        [JsonPropertyName("ID")]
        public string Id { get; set; }
        [JsonPropertyName("Secret")]
        public string Secret { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("IsExtension")]
        public bool IsExtension { get; set; }
    }

    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("scope")]
        public string[] Scopes { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}

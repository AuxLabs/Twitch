using AuxLabs.SimpleTwitch.Rest.Models;
using AuxLabs.SimpleTwitch.Rest.Requests;
using RestEase;
using System.Net.Http.Headers;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TwitchRestApiClient : ITwitchApi, IDisposable
    {
        private readonly ITwitchApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public string ClientId { get => _api.ClientId; set => _api.ClientId = value; }

        public TwitchRestApiClient()
            : this(TwitchConstants.BaseUrl) { }
        public TwitchRestApiClient(string baseUrl)
            : this(new HttpClient { BaseAddress = new Uri(baseUrl) }) { }
        public TwitchRestApiClient(HttpClient httpClient)
        {
            _api = new RestClient(httpClient)
            {
                RequestBodySerializer = new Net.JsonBodySerializer(),
                ResponseDeserializer = new Net.JsonResponseDeserializer(),
                RequestQueryParamSerializer = new Net.JsonQueryParamSerializer(),
            }.For<ITwitchApi>();
        }

        public void Dispose() => _api.Dispose();

        public Task<TwitchResponse<Commercial>> PostCommercialAsync([Body] PostChannelCommercialParams args)
            => _api.PostCommercialAsync(args);

        public Task<TwitchResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync([Query] GetExtensionAnalyticsParams args)
        {
            throw new NotImplementedException();
        }

        public Task<TwitchResponse<User>> GetUsersAsync([Query] GetUsersParams args)
            => _api.GetUsersAsync(args);
    }
}
